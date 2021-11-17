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
    public GameObject roadPart;
    public GameObject roadHalfPart;

    public void Start()
    {
        partRemover += removePart;

        roadBuild();
    }

    public void roadBuild()
    {
        GameObject newRoadPart;
        int roadPosition;

        for (roadPosition = 6; roadPosition < 400; roadPosition += 6)
        {
            newRoadPart = Instantiate(roadPart, new Vector3(0, -0.55f, roadPosition), Quaternion.Euler(new Vector3(0, 0, 0)));
            newRoadPart.transform.SetParent(road.transform);
        }

        randomizer();
    }

    public void randomizer()
    {
        GameObject newObstacle;
        int obstaclePosition;
        int cubePosition;

        for (obstaclePosition = 20; obstaclePosition < roadHalfPart.GetComponent<Renderer>().bounds.size.z * road.transform.childCount; obstaclePosition += 20)
        {
            newObstacle = Instantiate(obstaclePrefab, new Vector3(0, -0.05f, obstaclePosition), Quaternion.Euler(new Vector3(0, 0, 0)));
            removePart(newObstacle);
        }

        for (cubePosition = 15; cubePosition < roadHalfPart.GetComponent<Renderer>().bounds.size.z * road.transform.childCount - 20; cubePosition += 10)
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
