using System;
using UnityEngine;

public class FadeOutColliderV02 : MonoBehaviour
{
    //public GameObject Controller;
    public float LineStartTime;
    public float LineEndTime;
    //public float LoopJumpDist = 50f;

    void start()
    {
        //var CurrentLineAttributes = Controller.GetComponent<LineAttributesV01>();
    }

    private void OnTriggerEnter(Collider CurrentLineObject)
    {

        //print(CurrentLineObject.name);


        var CurLineObjTransform = CurrentLineObject.transform;
        var TrailChild = CurLineObjTransform.Find("TrailChild").gameObject;
        var FadeOutLineScript = TrailChild.GetComponent<FadeOutLineV02>();

        var CurrentLineAttributes = TrailChild.GetComponent<LineAttributesV01>();
        var VerticeTimes = CurrentLineAttributes.VectTime;

        var CurrentLineVertices = CurrentLineAttributes.Vertices;
        var TrailRenderer = TrailChild.GetComponent<TrailRenderer>();

        //_Update all the verts with the new position
        var NumVerts = VerticeTimes.Length;
       
        LineStartTime = VerticeTimes[0];
        LineEndTime = VerticeTimes[NumVerts - 1];
        var LineDrawTime = LineEndTime - LineStartTime;
        //print(LineDrawTime);



        FadeOutLineScript.enabled = true;   
        FadeOutLineScript.LineStartTime = Time.fixedTime;
        FadeOutLineScript.LineEndTime = FadeOutLineScript.LineStartTime + LineDrawTime;


    }

}
