// V01:
//Redraws the line when you press mouse button 2. 
//The code for this is a bit complicated because it was drawing a line between the end and start points.
// V02:

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehaviourV02 : MonoBehaviour
{

    public int CurrentWaypoint;



    void Start()
    {
        CurrentWaypoint = 0;

        var CurrentLineAttributes = this.GetComponent<LineAttributesV01>();
        this.transform.position = CurrentLineAttributes.Vertices[CurrentWaypoint];
        var TrailRenderer = this.GetComponent<TrailRenderer>();
        TrailRenderer.emitting = true;


    }


    void Update()
    {

        var CurrentLineAttributes = this.GetComponent<LineAttributesV01>();
        var CurrentLineVertices = CurrentLineAttributes.Vertices;
        var TrailRenderer = this.GetComponent<TrailRenderer>();

        //This code stops a line being drawn between the end and start points.
        if (CurrentWaypoint == 0)
        {
            this.transform.position = CurrentLineVertices[CurrentWaypoint];
            CurrentWaypoint++;
            TrailRenderer.Clear();
        }

        else if (CurrentWaypoint == (CurrentLineVertices.Length -1))
        {
            TrailRenderer.emitting = false;
            CurrentWaypoint = 0;
            this.enabled = false;
        }

        else
        {
            TrailRenderer.emitting = true;
            this.transform.position = CurrentLineVertices[CurrentWaypoint];
            CurrentWaypoint++;
        }
        




    }


}
