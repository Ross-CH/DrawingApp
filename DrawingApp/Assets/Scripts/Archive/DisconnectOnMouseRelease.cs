using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisconnectOnMouseRelease : MonoBehaviour
{
   
    void Update()
    {
        TrailRenderer TrailRenderComponent = GetComponent<TrailRenderer>();

        if (Input.GetMouseButtonUp(0))
        {
            TrailRenderComponent.emitting = false;
            //GetComponent<StickToObject>().enabled = false;
            GetComponent<DisconnectOnMouseRelease>().enabled = false;
            
        }
        
    }
}
