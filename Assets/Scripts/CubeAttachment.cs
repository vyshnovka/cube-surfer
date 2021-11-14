using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeAttachment : MonoBehaviour
{
    public Action<Collision, float> cubeAttach;
    public Action<Collision> cubeDetach;

    private float posX;

    public void Start()
    {
        cubeAttach += Attachment;
    }

    public void OnCollisionEnter(Collision collision)
    {
        posX = transform.position.x;
        cubeAttach(collision, posX);
    }

    public void Attachment(Collision collision, float posX)
    {
        //collision.transform.position.x = posX;
        collision.transform.parent = transform.parent;
    }
}
