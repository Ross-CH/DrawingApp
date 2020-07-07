//V01: Draws lines using the TrailRenderer and converts them to meshes when the mouse button is released.
//V02: Mesh Conversion removed. While the conversion is seamless, it raises a number of issues including a tendency for lines to blink out of existence when near the camera.


using UnityEngine;
using System;


public class RecordObjectMovementV02 : MonoBehaviour
{
    //+++++++++++++++++++  Remove this once working!!!!
    private GameObject CurrentLineObject;
    public GameObject Cursor;
   

    public GameObject LinePrefab; //this object holds the TrailRenderer
                                  
    public string[] ListOfLines = new string[0];
    public int CurrentLineNumber;
    private int Verts; 
    private Vector3 CamrayPoint;

    void Start()
    {
        Array.Resize(ref ListOfLines, 0);
        CurrentLineNumber = 0;
        Verts = 0;
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

            RaycastHit camray;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out camray, float.PositiveInfinity))
				if (camray.collider != null)
				{
                    Verts = Verts + 1;
                    CamrayPoint = camray.point;
                    drawLine();
                }
        }


    }

    void CreateLineObject()
    {
        Verts = 0;

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
                //Array.Resize(ref VerticesArray, 0);

                CurrentLineNumber++;
            }

    }

    void drawLine()
    {
        //_______________________________Get the current Line object
        int CurrentLineNum = ListOfLines.Length;
        var CurLineName = ListOfLines[CurrentLineNum - 1];
        CurrentLineObject = GameObject.Find(CurLineName);

        //Access the object script that stores it's data
        var CurrentObjectData = CurrentLineObject.GetComponent<LineAttributesV01>();


        //_______________________________Change the length of the Object's Data Lists by adding the new verts
        Array.Resize(ref CurrentObjectData.Vertices, Verts);
        Array.Resize(ref CurrentObjectData.VectTime, Verts);


        //_______________________________Assign the new vertice with the X, Y, & Z positional data of the Mouse
        CurrentObjectData.Vertices[(Verts - 1)] = CamrayPoint;
        //_______________________________Assign the new vertice with the current time
        CurrentObjectData.VectTime[(Verts - 1)] = Time.time;




    }




}


