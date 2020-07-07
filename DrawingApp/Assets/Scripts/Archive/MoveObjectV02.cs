using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MoveObjectV02 : MonoBehaviour
{

    void Update()
    {
        //mf = GetComponent();
        if (Input.GetKey("up"))
        {

            // Move the object forward along its z axis 1 unit/second.
            transform.Translate(Vector3.forward * Time.deltaTime);

            // Move the object upward in world space 1 unit/second.
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        }
    }
}