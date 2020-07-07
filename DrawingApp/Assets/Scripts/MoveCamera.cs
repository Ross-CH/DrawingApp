using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //public GameObject Canvas;
    //public GameObject Controller;
    public float CamSpeed;
  

    // Update is called once per frame
    void Update()
    {

        //Canvas.transform.Translate(0.0f, 0.0f, CamSpeed);
        //Controller.transform.Translate(0.0f, 0.0f, CamSpeed);
        transform.Translate(Vector3.forward * (Time.deltaTime*CamSpeed));

    }
}
