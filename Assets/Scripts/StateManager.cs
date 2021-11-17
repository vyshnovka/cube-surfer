using System;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static Action noCubesLeft;
    public static Action finish;

    public GameObject cubeStack;
    public GameObject finishLine;

    public void Start()
    {
        noCubesLeft += playerFail;
        finish += playerWin;
    }

    public void playerFail()
    {
        if (cubeStack.transform.childCount == 2)
        {
            print("Game over!");
            Time.timeScale = 0;
        }
    }

    public void playerWin()
    {
        print("Win!");
        Time.timeScale = 0;
    }
}
