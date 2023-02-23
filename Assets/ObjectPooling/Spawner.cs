using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;                   // The prefab to be spawned
    public float spawnRadius = 20f;              // The radius within which the object will spawn
    public float spawnCount = 3000;             // The number of objects to spawn

    public Material[] materials;                // The materials to be used on the spawned objects
    public List<GameObject> shapePool;          // The pool of objects

    private float timer;                        // The timer for spawning objects
    public int checkPoint = 0;                  // The checkpoint for the pool
    public GameObject shapeParent;              // The parent object for the spawned objects

    void Awake()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = transform.position.y;
        var shape = Instantiate(prefab, spawnPosition, Quaternion.identity);
        shape.gameObject.GetComponent<Renderer>().material = materials[Random.Range(0, materials.Length)];
        shape.gameObject.SetActive(false);
        shapePool.Add(shape);
        shape.transform.parent = shapeParent.transform;
    }

    /*void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.1f)
        {
            timer = 0;
            SpawnShape();            
        }
    }*/

    public void OpenShape(float spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
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
