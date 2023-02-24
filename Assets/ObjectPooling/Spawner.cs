using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    Controller controller;
    public Material[] materials;                // The materials to be used on the spawned objectsprivate float timer;
    public GameObject shapeParent;              // The parent object for the spawned objects

    void Start()
    {
        controller = Controller.instance;

        for (int i = 0; i < controller.spawnCount; i++)
        {
            Spawn();
        }

        if (instance == null)
        {
            instance = this;
        }
    }

    void Spawn()
    {
        var shape = Instantiate(controller.prefab, transform.position, Quaternion.identity);
        shape.gameObject.GetComponent<Renderer>().material = materials[Random.Range(0, materials.Length)];
        shape.gameObject.SetActive(false);
        controller.shapePool.Add(shape);
        shape.transform.parent = shapeParent.transform;
    }


}
