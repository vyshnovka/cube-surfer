using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeAttachment : MonoBehaviour
{
    public Action<GameObject> cubeAttach;
    public Action<Collision> cubeDetach;

    public void Start()
    {
        cubeAttach += Attachment;
    }

    public void OnCollisionEnter(Collision collision)
    {
        cubeAttach(collision.gameObject);
    }

    public void Attachment(GameObject other)
    {
        other.transform.position = new Vector3(transform.position.x, transform.position.y + GetComponent<Renderer>().bounds.size.y, transform.position.z);
        other.transform.parent = transform.parent;
    }
}
