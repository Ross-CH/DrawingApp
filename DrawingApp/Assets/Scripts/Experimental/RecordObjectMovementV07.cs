//V01: 
//Draws lines using the TrailRenderer and converts them to meshes when the mouse button is released.
//V02: 
//Mesh Conversion removed. While the conversion is seamless, it raises a number of issues including a tendency for lines to blink out of existence when near the camera.
//V03: 
//Clears the line then redraws it.
//Moves the line to a new position when the right mouse button is pressed.

using UnityEngine;
using System;


public class RecordObjectMovementV07 : MonoBehaviour
{
    //+++++++++++++++++++  Remove this once working!!!!
    private GameObject CurrentLineObject;
    public GameObject Cursor;
    public GameObject LinePrefab; //this object holds the TrailRenderer
    private int LoopFrame;
    private int LoopLength; //The number of frames before objects move and redraw
    public Color CurColour;
    public float CurAlpha;

     private string[] ListOfLines = new string[0];
    private int CurrentLineNumber;
    private int Verts; 
    private Vector3 CamrayPoint;
    private Gradient CurGradient;


    void Start()
    {
        Array.Resize(ref ListOfLines, 0);
        CurrentLineNumber = 0;
        Verts = 0;
        LoopFrame = 0;
    }



    void Update()
    {
       
        //____ If the mouse button is pressed, create a new line object
        if (Input.GetMouseButtonDown(0))
        {  
            CreateLineObject();     
        }


        if (Input.GetMouseButtonDown(1))
            {
            RedrawLine();
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


        if (Input.GetMouseButtonUp(0))
        {
            int CurrentLineNum = ListOfLines.Length;
            var CurLineName = ListOfLines[CurrentLineNum - 1];
            //CurrentLineObject = GameObject.Find(CurLineName);
            //TrailRenderer Line = CurrentLineObject.GetComponent<TrailRenderer>();
            //Line.emitting = false;

        }


        LoopFrame++;
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
                //int CFrame = LoopFrame;
                //NewObject.tag = Convert.ToString(LoopFrame);
                

                TrailRenderer Trail = NewObject.GetComponent<TrailRenderer>();
                CurGradient = Trail.colorGradient;
                Trail.emitting = true;
                Trail.material.color = Color.white;
 
                Array.Resize(ref ListOfLines, ListOfLines.Length + 1);
                ListOfLines[CurrentLineNumber] = NewObject.name;

                //Set the colour of current line object's gradient 
                Gradient gradient = new Gradient();
                gradient.SetKeys
                    (
                    new GradientColorKey[] { new GradientColorKey(CurColour, 0.0f), new GradientColorKey(CurColour, 1.0f) },
                    new GradientAlphaKey[] { new GradientAlphaKey(CurAlpha, 0.0f), new GradientAlphaKey(CurAlpha, 1.0f) }
                    );
                Trail.colorGradient = gradient;

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


    void RedrawLine()
    {
        int CurrentLineNum = ListOfLines.Length;
        var CurLineName = ListOfLines[CurrentLineNum - 1];
        CurrentLineObject = GameObject.Find(CurLineName);

//_Access the object script that runs it's draw animation
        var RedrawLineScript = CurrentLineObject.GetComponent<LineBehaviourV02>();
        
//_Copy the Line Data into this object's own Data Lists  *****This should be moved to 'void.start' once I've got it working properly!
        var CurrentLineAttributes = CurrentLineObject.GetComponent<LineAttributesV01>();
        var CurrentLineVertices = CurrentLineAttributes.Vertices;

//_Update all the verts with the new position
        var NumVerts = CurrentLineVertices.Length;

        for (int i = 0; i < NumVerts; i++)
        {
            var Vector3Val = CurrentLineVertices[i];

            float Xpos = Vector3Val.x;
            float Ypos = Vector3Val.y;
            float Zpos = Vector3Val.z;

            Zpos = Zpos + 1.5f;

            CurrentLineAttributes.Vertices[i].Set(Xpos, Ypos, Zpos);
        }
//_

        RedrawLineScript.enabled = true;
        //var CurrentWaypoint = RedrawLineScript.CurrentWaypoint;
        //CurrentWaypoint = 0;

    }




}


