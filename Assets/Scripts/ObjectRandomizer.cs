using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandomizer : MonoBehaviour
{
    public Action<GameObject> partRemover;
    public GameObject obstaclePrefab;
    public GameObject cubePrefab;

    public GameObject road;

    public void Start()
    {
        partRemover += removePart;

        randomizer();
    }

    public void randomizer()
    {
        GameObject newObstacle;
        int obstaclePosition;
        int cubePosition;

        for (obstaclePosition = 20; obstaclePosition < road.GetComponent<Renderer>().bounds.size.z; obstaclePosition += 20)
        {
            newObstacle = Instantiate(obstaclePrefab, new Vector3(0, -0.05f, obstaclePosition), Quaternion.Euler(new Vector3(0, 0, 0)));
            removePart(newObstacle);
        }

        for (cubePosition = 15; cubePosition < road.GetComponent<Renderer>().bounds.size.z - 20; cubePosition += 10)
        {
            Instantiate(cubePrefab, new Vector3(0, 0, cubePosition), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    public void removePart(GameObject obstacle)
    {
        int count;
        int range;

        foreach (Transform child in obstacle.transform)
        {
            count = 0;
            range = UnityEngine.Random.Range(0, 2);

            while (count < range)
            {
                if (UnityEngine.Random.value > 0.5f)
                {
                    child.gameObject.SetActive(false);
                }

                count++;
            }
        }
    }
}
