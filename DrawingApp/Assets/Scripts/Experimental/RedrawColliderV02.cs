using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedrawColliderV02 : MonoBehaviour
{
    public GameObject Controller;
    public float LoopJumpDist = 50f;

    void start()
    {
        //var CurrentLineAttributes = Controller.GetComponent<LineAttributesV01>();
    }

    private void OnTriggerEnter(Collider CurrentLineObject)
    {
       

        var CurLineObjTransform = CurrentLineObject.transform;
        var TrailChild = CurLineObjTransform.Find("TrailChild").gameObject;
        var RedrawLineScript = TrailChild.GetComponent<RedrawLineV01>();
        var FadeOutLineScript = TrailChild.GetComponent<FadeOutLineV02>();

        //_Copy the Line Objects's line positions
        var CurrentLineAttributes = TrailChild.GetComponent<LineAttributesV01>();
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

        //_Move the collider to the first line position
        CurrentLineObject.transform.position = CurrentLineVertices[0];

        RedrawLineScript.enabled = true;
        RedrawLineScript.CurrentWaypoint = 0;
        RedrawLineScript.CreationTime = Time.fixedTime;

        // reset the gradient alpha values
        var LineGradient = CurrentLineAttributes.ColGradient;
        var TrailRenderer = TrailChild.GetComponent<TrailRenderer>();
        //var TRGradient = TrailRenderer.colorGradient;
        TrailRenderer.colorGradient = LineGradient;



    }

}
