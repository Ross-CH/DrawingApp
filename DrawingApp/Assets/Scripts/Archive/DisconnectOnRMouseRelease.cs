﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisconnectOnRMouseRelease : MonoBehaviour
{
   
    void Update()
    {
        TrailRenderer TrailRender = GetComponent<TrailRenderer>();

        if (Input.GetMouseButtonUp(1))
        {
        GetComponent<StickToObject>().enabled = false;
        TrailRender.emitting = false;
        GetComponent<DisconnectOnRMouseRelease>().enabled = false;
        }
        
    }
}
