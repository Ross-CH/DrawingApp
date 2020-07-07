// V01:
//Redraws the line when you press mouse button 2. 
//The code for this is a bit complicated because it was drawing a line between the end and start points.
// V02:

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedrawLineV01 : MonoBehaviour
{

    public int CurrentWaypoint;
    private TrailRenderer TrailRenderer;
    public float CreationTime;
    //public float PauseBeforeFadeOut = 6.0f;


    void Start()
    {
        CurrentWaypoint = 0;

        var CurrentLineAttributes = this.GetComponent<LineAttributesV01>();
        this.transform.position = CurrentLineAttributes.Vertices[CurrentWaypoint];
        TrailRenderer = this.GetComponent<TrailRenderer>();
        TrailRenderer.emitting = true;

    }


    void Update()
    {

        //_Copy the Line Objects's line positions
        var CurrentLineAttributes = this.GetComponent<LineAttributesV01>();
        var CurrentLineVertices = CurrentLineAttributes.Vertices;



        //This code stops a line being drawn between the end and start points.
        if (CurrentWaypoint == 0)
        {
            this.transform.position = CurrentLineVertices[CurrentWaypoint];
            CurrentWaypoint++;
            TrailRenderer.Clear();
        }

        else if (CurrentWaypoint == (CurrentLineVertices.Length -1))
        {
            var LastPosition = CurrentLineVertices[CurrentLineVertices.Length - 1];
            TrailRenderer.emitting = false;
            CurrentWaypoint = 0;
            this.enabled = false;
            this.transform.position = LastPosition;
        }

        else
        {
            TrailRenderer.emitting = true;
            this.transform.position = CurrentLineVertices[CurrentWaypoint];
            CurrentWaypoint++;
            //print(CurrentWaypoint);
        }

    }


}
