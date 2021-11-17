using System;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static Action noCubesLeft;

    public void Start()
    {
        noCubesLeft += playerFail;
    }

    public void playerFail()
    {
        if (transform.childCount == 2)
        {
            print("Game over!");
            Time.timeScale = 0;
        }
    }
}
