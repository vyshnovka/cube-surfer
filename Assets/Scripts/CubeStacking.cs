using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeStacking : MonoBehaviour
{
    public Action<GameObject> cubeAttach;
    public Action<GameObject> cubeDetach;

    public void Start()
    {
        cubeAttach += Attachment;
        cubeDetach += Detachment;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube" && collision.transform.parent == null)
        {
            cubeAttach(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            cubeDetach(collision.gameObject);
        }
    }

    public void Attachment(GameObject other)
    {
        other.transform.position = new Vector3(transform.position.x, transform.position.y + GetComponent<Renderer>().bounds.size.y * (transform.parent.childCount - 1) + 0.1f, transform.position.z);
        other.AddComponent<CubeStacking>();
        other.transform.parent = transform.parent;
    }

    public void Detachment(GameObject other)
    {
        foreach (Transform child in other.transform.parent)
        {
            child.tag = "Untagged";
        }

        transform.parent = null; //maybe this is wrong?
    }

    public void OnDestroy()
    {
        cubeAttach -= Attachment;
        cubeDetach -= Detachment;
    }
}
