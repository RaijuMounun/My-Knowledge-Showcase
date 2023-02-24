using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public int value;
    Controller controller;
    public bool interacted;

    void Start()
    {
        controller = Controller.instance;
    }

    void Update()
    {
        if (interacted == true)
        {
            print("interacted");
            OpenShapes();
            interacted = false;
        }
    }

    void OpenShapes()
    {
        print("OpenShapes");
        controller.OpenShape(value);
    }

}
