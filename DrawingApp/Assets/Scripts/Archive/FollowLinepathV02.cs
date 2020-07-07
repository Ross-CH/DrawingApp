//V02: The path following now works by using a 'frame counter' to run through 
//the vertex positions of the path one frame at a time instead of using any kind of interpolation
//V03: 

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLinepathV02 : MonoBehaviour
{

    private GameObject Controller;
    private GameObject CurrentLineObject;
    private int CurrentWaypoint;
    public Vector3[] CurrentLineVertices = new Vector3[0];
    public float[] CurrentLineTimes = new float[0];



    void Start()
    {
        CurrentWaypoint = 0;
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


            this.transform.position = CurrentLineVertices[CurrentWaypoint];


        }
    }

    void Update()
    {

        this.transform.position = CurrentLineVertices[CurrentWaypoint];
        CurrentWaypoint ++ ;

        if (CurrentWaypoint > CurrentLineVertices.Length)
        {
            CurrentWaypoint = 0;
        }
        
    }
    // Update is called once per frame

}
