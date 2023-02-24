using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeController : MonoBehaviour
{
    float timer;

    void Update()
    {
        if (this.gameObject.activeInHierarchy == true)
        {
            var time = Random.Range(3, 7);
            timer += Time.deltaTime;
            if (timer > time)
            {
                timer = 0;
                gameObject.SetActive(false);
            }
        }
    }
}
