using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimInteraction : MonoBehaviour
{
    Controller controller;

    void Awake()
    {
        controller = Controller.instance;
    }
    void Update()
    {
        float rayDistance = 1000.0f;
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rayDistance, Color.green);
        RaycastHit rayHit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out rayHit, 1000.0f))
        {
            GameObject hitObject = rayHit.collider.gameObject;

            if ((hitObject.GetComponent<Buttons>() != null) & (Input.GetKeyDown(KeyCode.E)))
            {
                hitObject.GetComponent<Buttons>().interacted = true;
            }
        }
    }
}
