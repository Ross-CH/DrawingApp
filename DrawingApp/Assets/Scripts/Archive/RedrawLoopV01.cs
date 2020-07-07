// V01:



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedrawLoopV01 : MonoBehaviour
{

    private int CurrentWaypoint;



    void Start()
    {
        CurrentWaypoint = 0;

        //______________________Copy the Line Data into this object's own Data Lists  *****This should be moved to 'void.start' once I've got it working properly!

        var CurrentLineAttributes = this.GetComponent<LineAttributesV01>();
        var CurrentLineVertices = CurrentLineAttributes.Vertices;
        this.transform.position = CurrentLineVertices[CurrentWaypoint];
        var TrailRenderer = this.GetComponent<TrailRenderer>();



    }


    void Update()
    {

        var CurrentLineAttributes = this.GetComponent<LineAttributesV01>();
        var CurrentLineVertices = CurrentLineAttributes.Vertices;
        var TrailRenderer = this.GetComponent<TrailRenderer>();


        //reset the animation without drawing a line between the end point and the start point.
        if (CurrentWaypoint == 1)
        {
            TrailRenderer.Clear();
            TrailRenderer.emitting = true;
        }


        if (CurrentWaypoint == (CurrentLineVertices.Length -1))
        {
            
            TrailRenderer.emitting = false;
            TrailRenderer.Clear();
            CurrentWaypoint = 0;
        }
        
        this.transform.position = CurrentLineVertices[CurrentWaypoint];
        CurrentWaypoint ++ ;
        
        
        
    }


}
