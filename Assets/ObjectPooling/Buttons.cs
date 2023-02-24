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
            OpenShapes();
            interacted = false;
        }
    }

    void OpenShapes()
    {
        controller.OpenShape(value);
    }

}
