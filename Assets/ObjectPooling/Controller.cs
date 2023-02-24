using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    public GameObject prefab;                   // The prefab to be spawned
    public float spawnCount = 3000;             // The number of objects to spawn
    public float spawnRadius = 20f;              // The radius within which the object will spawn
    public List<GameObject> shapePool;          // The pool of objects
    public int checkPoint;                  // The checkpoint for the pool


    //testing
    public bool one, ten, hundred, thousand;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (one)
        {
            OpenShape(1);
            one = false;
        }
        if (ten)
        {
            OpenShape(10);
            ten = false;
        }
        if (hundred)
        {
            OpenShape(100);
            hundred = false;
        }
        if (thousand)
        {
            OpenShape(1000);
            thousand = false;
        }
    }


    public void OpenShape(int openCount)
    {
        for (int i = 0; i < openCount; i++)
        {
            if (checkPoint < shapePool.Count)
            {
                shapePool[checkPoint].transform.position = transform.position + Random.insideUnitSphere * spawnRadius;
                shapePool[checkPoint].SetActive(true);
                checkPoint++;
            }
            else if (checkPoint >= shapePool.Count)
            {
                checkPoint = 0;
                shapePool[checkPoint].transform.position = transform.position + Random.insideUnitSphere * spawnRadius;
                shapePool[checkPoint].SetActive(true);
                checkPoint++;
            }
        }
    }
}
