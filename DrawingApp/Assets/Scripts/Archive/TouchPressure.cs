using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TouchPressure : MonoBehaviour
{ 


void Update()
{
    float touchPressure;

    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
    {
        // Get movement of the finger since last frame
        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        touchPressure = Input.GetTouch(0).pressure;
        print (touchPressure);
        // Move object across XY plane
    }
}
}
//________________________________________________________________
