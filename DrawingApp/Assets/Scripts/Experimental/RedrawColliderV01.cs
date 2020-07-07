using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedrawColliderV01 : MonoBehaviour
{
    public GameObject Controller;
    public float LoopJumpDist = 50f;

    void start()
    {
        //var CurrentLineAttributes = Controller.GetComponent<LineAttributesV01>();
    }

    private void OnTriggerEnter(Collider CurrentLineObject)
    {
        //print(other.name);

        var RedrawLineScript = CurrentLineObject.GetComponent<RedrawLineV01>();

        //_Copy the Line Objects's line positions
        var CurrentLineAttributes = CurrentLineObject.GetComponent<LineAttributesV01>();
        var CurrentLineVertices = CurrentLineAttributes.Vertices;

        //_Update all the verts with the new position
        var NumVerts = CurrentLineVertices.Length;

        //update the list of vertices with the new positions
        for (int i = 0; i < NumVerts; i++)
        {
            var Vector3Val = CurrentLineVertices[i];

            float Xpos = Vector3Val.x;
            float Ypos = Vector3Val.y;
            float Zpos = Vector3Val.z;

            Ypos = Ypos - LoopJumpDist;

            CurrentLineAttributes.Vertices[i].Set(Xpos, Ypos, Zpos);

        }
        //_
        
        RedrawLineScript.enabled = true;
        RedrawLineScript.CurrentWaypoint = 0;
        RedrawLineScript.CreationTime = Time.fixedTime;

    }

}
