//V01: Draws lines using the TrailRenderer and converts them to meshes when the mouse button is released.
//V02: Mesh Conversion removed. While the conversion is seamless, it raises a number of issues including a tendency for lines to blink out of existence when near the camera.
//V03: None yet!

using UnityEngine;
using System;


public class DrawTrailRenderV03 : MonoBehaviour
{
    //+++++++++++++++++++  Remove this once working!!!!
    //private LineRenderer LineRenderer; //this is the current LineRenderer
    private GameObject CurrentLineObject;
    private GameObject CanvasPlane;
    public GameObject Cursor;
   

    public GameObject LinePrefab; //this object holds the TrailRenderer
                                  
    public string[] ListOfLines = new string[1];
    public int CurrentLineNumber;
    public Vector3[] VerticesArray;
    private Vector3 LinePos;
    private int Verts; 
    private Vector3 CamrayPoint;

    void Start()
    {
        Array.Resize(ref ListOfLines, 0);
        CurrentLineNumber = 0;
    }



    void Update()
    {
       
        //____ If the mouse button is pressed, create a new line object
        if (Input.GetMouseButtonDown(0))
        {
            CreateLineObject();     
        }


        //____ If the mouse button is held down, move the current line object to the cursor object position.
        if (Input.GetMouseButton(0))
        {
            int CurrentLineNum = ListOfLines.Length;
            var CurLineName = ListOfLines[CurrentLineNum - 1];
            CurrentLineObject = GameObject.Find(CurLineName);
            CurrentLineObject.transform.position = Cursor.transform.position;
        }

        //____ If the mouse button is released, bake the TrailRenderer of the current line object into a mesh
        if (Input.GetMouseButtonUp(0))
        {
            int CurrentLineNum = ListOfLines.Length;
            var CurLineName = ListOfLines[CurrentLineNum - 1];
            CurrentLineObject = GameObject.Find(CurLineName);

            //BakeLine(CurrentLineObject);
        }


    }

    void CreateLineObject()
    {

        RaycastHit camray;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out camray, float.PositiveInfinity))
            if (camray.collider != null)
            {
                //_______________________________Add a new Line Object and add a LineRenderer to it
                var NewObject = (GameObject)Instantiate(LinePrefab, camray.point, transform.rotation);
                NewObject.name = ("Line_") + CurrentLineNumber.ToString();
                TrailRenderer Line = NewObject.GetComponent<TrailRenderer>();
                Line.emitting = true;
                Line.material.color = Color.white;
 
                Array.Resize(ref ListOfLines, ListOfLines.Length + 1);
                ListOfLines[CurrentLineNumber] = NewObject.name;

                //_______________________________Reset the Array of Vertices to 0
                Array.Resize(ref VerticesArray, 0);

                CurrentLineNumber++;
            }

    }







}


