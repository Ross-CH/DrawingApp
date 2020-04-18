using UnityEngine;
using System;


public class DrawLineRenderV01 : MonoBehaviour
{
    //Mesh m;
    //public MeshFilter mf;

    private LineRenderer lr;

    //______________________________Set the positions of the vertices that will form the line
    public Vector3 VecA;
	public Vector3 VecB;
	public Vector3 VecC;

    Vector3 NewVecA;
    Vector3 NewVecB;
    Vector3 NewVecC;

    public Vector3[] VerticesArray = new Vector3[0];
	public int[] TrianglesArray = new int[0];
	public int Verts;

	//public float CallFrequency;
    public Vector3 CamrayPoint;


	void Update()
	{
		if (Input.GetMouseButton(0))
		{

			RaycastHit camray;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out camray, float.PositiveInfinity))
				if (camray.collider != null)
				{
                    //______________________________Increase the vertice counter

                    Verts = Verts + 3;
                    CamrayPoint = camray.point;

                    drawTriangle();
                   
				}
		}
	}

    void drawTriangle()
    {
       

        //______________________________for each Vert, set the x position
        NewVecA[0] = VecA[0] + CamrayPoint.x;
        NewVecB[0] = VecB[0] + CamrayPoint.x;
        NewVecC[0] = VecC[0] + CamrayPoint.x;

        //______________________________for each Vert, set the y position
        NewVecA[1] = CamrayPoint.y;
        NewVecB[1] = CamrayPoint.y;
        NewVecC[1] = CamrayPoint.y;

        //______________________________for each Vert, set the z position
        NewVecA[2] = VecA[2] + CamrayPoint.z;
        NewVecB[2] = VecB[2] + CamrayPoint.z;
        NewVecC[2] = VecC[2] + CamrayPoint.z;

        //_______________________________Change the length of the Vertice array by adding the 3 new verts
        Array.Resize(ref VerticesArray, Verts);

        //_______________________________Assign the new vertices with the X, Y, & Z positional data of VecA, VecB & VecC
        VerticesArray[(Verts - 3)] = NewVecA;
        VerticesArray[(Verts - 2)] = NewVecB;
        VerticesArray[(Verts - 1)] = NewVecC;



        //_______________________________Change the length of the Triangle array by adding the 3 new verts
        Array.Resize(ref TrianglesArray, Verts);


        //_______________________________Arrange the sequential order of the vertices in each triangle
        TrianglesArray[(Verts - 3)] = (Verts - 3);
        TrianglesArray[(Verts - 2)] = (Verts - 2);
        TrianglesArray[(Verts - 1)] = (Verts - 1);

        //______________________________Update the mesh and the call the draw function
        //m = new Mesh();
        //_______________________________add these triangles to the mesh
        //m.vertices = VerticesArray;
        //m.triangles = TrianglesArray;

        //_______________________________Update the mesh filter with the new mesh
        //mf.mesh = m;
        lr = GetComponent<LineRenderer>();
        lr.positionCount = VerticesArray.Length;
        lr.SetPositions(VerticesArray);

    }
}


