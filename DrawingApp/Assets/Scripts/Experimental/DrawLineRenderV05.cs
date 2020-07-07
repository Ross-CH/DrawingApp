//Updates from V02: 
//nothing yet!

using UnityEngine;
using System;

public class DrawLineRenderV05 : MonoBehaviour
{
    //+++++++++++++++++++  Remove this once working!!!!
    //private LineRenderer LineRenderer; //this is the current LineRenderer
    private GameObject CurrentLineObject;
    private GameObject CanvasPlane;

    public GameObject LinePrefab; //this object holds the LineRenderer
    //public GameObject CanvasPlane; //This object is needed to fix the issue of the line moving when it's baked. I'm not sure what's causing it at the moment.
    //public int[] ListOfLines = new int[0]; //This is a list of the lines
    
    public string[] ListOfLines = new string[1];
    public int CurrentLineNumber;

    public Vector3[] VerticesArray;
    private Vector3 LinePos;
	private int Verts;

	//private float CallFrequency = 0.0f; //make this public if I want to set the frequency within Unity!
    private Vector3 CamrayPoint;

   void Start()
    {
        CurrentLineNumber = 0;
    }



	void Update()
	{
        //transform.Translate(0.0f,0.5f,0.0f);




        if (Input.GetMouseButtonDown(0))
        {

            //this.name = GetInstanceID().ToString();
            //print(this.name);

            RaycastHit camray;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out camray, float.PositiveInfinity))
                if (camray.collider != null)
                {
                    Verts = 0;
                    CreateLineObject();
                }
                   
        }

        if (Input.GetMouseButtonUp(0))
        {

            int CurrentLineNum = ListOfLines.Length;
            var CurLineName = ListOfLines[CurrentLineNum - 1];
            CurrentLineObject = GameObject.Find(CurLineName);

            BakeLine(CurrentLineObject);

        }


            if (Input.GetMouseButton(0))
		    {

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


        if (Input.GetKey("up"))
        {
            int CurrentLineNum = ListOfLines.Length;
            var CurLineName = ListOfLines[CurrentLineNum - 1];
            CurrentLineObject = GameObject.Find(CurLineName);
            CurrentLineObject.transform.Translate(Vector3.forward * Time.deltaTime);
            CurrentLineObject.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
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
                //NewObject.AddComponent<LineRenderer>();
                
                LineRenderer Line = NewObject.GetComponent<LineRenderer>();
                //Line.useWorldSpace = false;

                //_______________________________Set the number of vertices in the Linerenderer to 0       
                Line.positionCount = 0;


                //_______________________________Set the attributes of the line

                
                Line.SetWidth(0.01f, 0.13f);

                //These attributes could be added to a list of public variables stored in the object to allow more flexibility


                //_______________________________End of setting attributes


                //_______________________________Add the new object to the object list 
                Array.Resize(ref ListOfLines, ListOfLines.Length + 1);
                ListOfLines[CurrentLineNumber] = NewObject.name;

                //_______________________________Reset the Array of Vertices to 0
                Array.Resize(ref VerticesArray, 0);

                
                
                CurrentLineNumber++; 
            }

    }
    void drawLine()
    {
        //_______________________________Get the current Line object
        int CurrentLineNum = ListOfLines.Length;
        var CurLineName = ListOfLines[CurrentLineNum-1];
        CurrentLineObject = GameObject.Find(CurLineName);

        //_______________________________Get the LineRenderer of the current Line object
        LineRenderer Line = CurrentLineObject.GetComponent<LineRenderer>();

        //_______________________________Change the length of the Vertice array by adding the new verts
        Array.Resize(ref VerticesArray, Verts);

        //_______________________________Assign the new vertice with the X, Y, & Z positional data of the Mouse
        VerticesArray[(Verts - 1)] = CamrayPoint;

        //_______________________________Update the number of vertices in the Linerenderer and set the position of the new vertice
        Line.positionCount = VerticesArray.Length;
        Line.SetPositions(VerticesArray);
        
    }




    public static void BakeLine(GameObject gameObject)
    {
        
        RaycastHit camray;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out camray, float.PositiveInfinity))
            if (camray.collider != null)
            {
                var lineRenderer = gameObject.GetComponent<LineRenderer>();
                var meshFilter = gameObject.AddComponent<MeshFilter>();
                var LineMaterial = lineRenderer.material;
                Mesh mesh = new Mesh();

                var FirstVert = lineRenderer.GetPosition(0);

                lineRenderer.useWorldSpace = false;
                lineRenderer.BakeMesh(mesh);
                meshFilter.sharedMesh = mesh;


                var CanvasPlane = GameObject.Find("CanvasPlane");
                gameObject.transform.position = new Vector3(0.0f, (camray.point.y - CanvasPlane.transform.position.y), 0.0f);

                var meshRenderer = gameObject.AddComponent<MeshRenderer>();
                meshRenderer.material = LineMaterial;

                GameObject.Destroy(lineRenderer);
            }


                
       
    }





}


