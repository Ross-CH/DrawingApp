﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLinepath : MonoBehaviour
{

    private GameObject Controller;
    private GameObject CurrentLineObject;
    private int CurrentWaypoint;
    public Vector3[] CurrentLineVertices = new Vector3[0];
    public float[] CurrentLineTimes = new float[0];



    void Start()
    {
        CurrentWaypoint = 0;
       

    }

    // Update is called once per frame
    void Update()
    {
        //______________________Get the current line object from the object list held by the Controller object
        Controller = GameObject.Find("Controller");
        var RecordObjectsScript = Controller.GetComponent<RecordObjectMovementV01>();

        //______________________If the number oflines is greater than zero, find the current line
        var NumOfLines = RecordObjectsScript.ListOfLines.Length;
        if (NumOfLines > 0)
            { 
            var CurrentLine = RecordObjectsScript.ListOfLines[NumOfLines - 1];
            CurrentLineObject = GameObject.Find(CurrentLine);

            //______________________Find the Current Line Object's script that contains the Line Data
            var CurLinObjScript = CurrentLineObject.GetComponent<LineAttributesV01>();

            //______________________Copy the Line Data into this object's own Data Lists  *****This should be moved to 'void.start' once I've got it working properly!
            CurrentLineVertices = CurLinObjScript.Vertices;
            CurrentLineTimes = CurLinObjScript.VectTime;

            //copy the above data to  void.start

            //Get the position from the first waypoint
            
            //add 1 to the waypoint number to go to the next frame
        
            //if the current waypoint number exceeds the number of waypoints, deactivate this script.
        
        }






        //var CurrentLineVertice = CurLinObjScript.Vertices.Length - 1;
        //Array.Resize(ref CurrentLineVertices, CurLinObjScript.Vertices.Length);
        //CurrentLineVertices[CurrentLineVertice] = CurLinObjScript.Vertices[CurrentLineVertice];
    }
}
