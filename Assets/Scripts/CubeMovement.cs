using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float forwardSpeed = 1f;
    public float sideSpeed = 1f;

    //public float moveLimit = 5f;

    public void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Translate(Vector3.right * mouseX * sideSpeed * Time.deltaTime);
        }
    }
}
