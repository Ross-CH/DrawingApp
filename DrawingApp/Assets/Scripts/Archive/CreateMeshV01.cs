using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class CreateMeshV01 : MonoBehaviour
{
    Mesh m;
    public MeshFilter mf;
    // Use this for initialization

    public Vector3 VecA;
    public Vector3 VecB;
    public Vector3 VecC;
    public float CallFrequency;

    public Vector3[] VerticesArray = new Vector3[0];
    public int[] TrianglesArray = new int[0];
    public int Verts;


    void Start()
    {
        //______________________________Only run the "WhenKeyPressed" function every (CallFrequency) of a second after a delay of 0.0f
        InvokeRepeating("WhenKeyPressed", 0.0f, CallFrequency);
    }

    void WhenKeyPressed()
    {
        //mf = GetComponent();
        if (Input.GetKey("up"))
        {
            //______________________________Increase the vertice counter

            Verts = Verts + 3;


            //______________________________for each Vert, set the x position
            VecA[0] = VecA[0] + 1;
            VecB[0] = VecB[0] + 1;
            VecC[0] = VecC[0] + 1;

            //______________________________for each Vert, set the y position
            VecA[1] = VecA[1] + 2;
            VecB[1] = VecB[1] + 2;
            VecC[1] = VecC[1] + 2;

            //______________________________for each Vert, set the z position
            VecA[2] = VecA[2] + 0;
            VecB[2] = VecB[2] + 0;
            VecC[2] = VecC[2] + 0;

            //_______________________________Change the length of the Vertice array by adding the 3 new verts
            Array.Resize(ref VerticesArray, Verts);

            //_______________________________Assign the new vertices with the X, Y, & Z positional data of VecA, VecB & VecC
            VerticesArray[(Verts - 3)] = VecA;
            VerticesArray[(Verts - 2)] = VecB;
            VerticesArray[(Verts - 1)] = VecC;



            //_______________________________Change the length of the Triangle array by adding the 3 new verts
            Array.Resize(ref TrianglesArray, Verts);


            //_______________________________Arrange the sequential order of the vertices in each triangle
            TrianglesArray[(Verts - 3)] = (Verts - 3);
            TrianglesArray[(Verts - 2)] = (Verts - 2);
            TrianglesArray[(Verts - 1)] = (Verts - 1);

            //______________________________Update the mesh and the call the draw function
            m = new Mesh();

            drawTriangle();



        }


    }




    //This draws a triangle
    void drawTriangle()
    {
        //We need two arrays one to hold the vertices and one to hold the triangles
        //Vector3[] VerticesArray = new Vector3[3];
        //int[] trianglesArray = new int[3];



        //VerticesArray[0] = VecA;
        //VerticesArray[1] = VecB;
        //VerticesArray[2] = VecC;

        //define the order in which the vertices in the VerteicesArray should be used to draw the triangle
        //TrianglesArray[0] = 0;
        //TrianglesArray[1] = 1;
        //TrianglesArray[2] = 2;

        //add these two triangles to the mesh
        m.vertices = VerticesArray;
        m.triangles = TrianglesArray;


        //_______________________________Update the mesh filter with the new mesh
        mf.mesh = m;

    }


}