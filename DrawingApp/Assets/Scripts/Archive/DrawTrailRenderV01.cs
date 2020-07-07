//V01: Draws lines using the TrailRenderer and converts them to meshes when the mouse button is released.


using UnityEngine;
using System;


public class DrawTrailRenderV01 : MonoBehaviour
{
    //+++++++++++++++++++  Remove this once working!!!!
    //private LineRenderer LineRenderer; //this is the current LineRenderer
    private GameObject CurrentLineObject;
    private GameObject CanvasPlane;
    public GameObject Cursor;
   

    public GameObject LinePrefab; //this object holds the LineRenderer
                                  
    public string[] ListOfLines = new string[1];
    public int CurrentLineNumber;
    public Vector3[] VerticesArray;
    private Vector3 LinePos;
    private int Verts; 
    private Vector3 CamrayPoint;

    void Start()
    {
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

            BakeLine(CurrentLineObject);
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



    public static void BakeLine(GameObject gameObject)
    {

        RaycastHit camray;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out camray, float.PositiveInfinity))
            if (camray.collider != null)
            {
                var TrailRenderer = gameObject.GetComponent<TrailRenderer>();
                var StickToCursorScript = gameObject.GetComponent<StickToCursor>();
                var LineMaterial = TrailRenderer.material;


                //______Create a mesh to copy the TrailRenderer vertices to

                var meshFilter = gameObject.AddComponent<MeshFilter>();
                Mesh mesh = new Mesh();//_____ Add a mesh to the line object
                TrailRenderer.BakeMesh(mesh);//_____ Bake the TrailRenderer to the new mesh
                meshFilter.sharedMesh = mesh;//_____ update the mesh renderer with the new mesh (I think)


                //______Convert the vertices of the mesh to LocalSpace to match the worldspace of the Linerenderer
              
                Vector3[] NewVertices = new Vector3[mesh.vertexCount];// Create a list of Vector3 vertices the same size as the new mesh

                // Update the positions of the vertexes to LocalSpace
                for (int i = 0; i < mesh.vertexCount; i++)
                {
                    NewVertices[i] = gameObject.transform.InverseTransformPoint(mesh.vertices[i]);
                }
                    mesh.vertices = NewVertices;


                //Remove the TrailRenderer as the mesh has now been created.
                GameObject.Destroy(TrailRenderer); 

            }




    }





}


