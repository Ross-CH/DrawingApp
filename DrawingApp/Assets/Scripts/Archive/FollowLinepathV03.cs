//Updates from V02: 
//The script now works on the object it's attached to instead of a separate object
// The Line redraws constantly without having the unwanted line connecting the start and end points.


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLinepathV03 : MonoBehaviour
{

    //private GameObject Controller;
    //private GameObject CurrentLineObject;
    private int CurrentWaypoint;
    //public Vector3[] CurrentLineVertices = new Vector3[0];
    //public float[] CurrentLineTimes = new float[0];



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
        
        
        
        if (CurrentWaypoint == 1)
        {
            TrailRenderer.Clear();
            TrailRenderer.emitting = true;
        }


        if (CurrentWaypoint == (CurrentLineVertices.Length -1))
        {
            //reset the animation without drawing a line between the end point and the start point.
            TrailRenderer.emitting = false;
            TrailRenderer.Clear();
            CurrentWaypoint = 0;
        }
        
        this.transform.position = CurrentLineVertices[CurrentWaypoint];
        CurrentWaypoint ++ ;
        
        
        
    }


}
