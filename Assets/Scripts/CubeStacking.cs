using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeStacking : MonoBehaviour
{
    public Action<GameObject> cubeAttach;
    public Action<GameObject> cubeDetach;

    public GameObject parentFree;

    public void Start()
    {
        cubeAttach += Attachment;
        cubeDetach += Detachment;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            cubeAttach(collision.gameObject);
        }
        else
        {
            cubeDetach(collision.gameObject);
        }
    }

    public void Attachment(GameObject other)
    {
        other.transform.position = new Vector3(transform.position.x, transform.position.y + GetComponent<Renderer>().bounds.size.y + 0.05f, transform.position.z);
        other.transform.parent = transform.parent;
    }

    public void Detachment(GameObject other)
    {
        transform.parent = parentFree.transform;
    }
}
