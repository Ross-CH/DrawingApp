using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertLineToMesh : MonoBehaviour
{
    // Start is called before the first frame update
    public static void BakeLine(GameObject gameObject)
    {
        
        var lineRenderer = gameObject.GetComponent<LineRenderer>();
        var meshFilter = gameObject.AddComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        lineRenderer.BakeMesh(mesh);
        meshFilter.sharedMesh = mesh;

        var meshRenderer = gameObject.AddComponent<MeshRenderer>();
        //meshRenderer.sharedMaterial = s_matDebug;

        GameObject.Destroy(lineRenderer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
