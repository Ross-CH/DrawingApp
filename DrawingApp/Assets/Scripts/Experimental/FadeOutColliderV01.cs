using System;
using UnityEngine;

public class FadeOutColliderV01 : MonoBehaviour
{
    //public GameObject Controller;
    public float LineStartTime;
    public float LineEndTime;
    private int CurrentWaypoint = 0;
    //public float LoopJumpDist = 50f;

    void start()
    {
        //var CurrentLineAttributes = Controller.GetComponent<LineAttributesV01>();
    }

    private void OnTriggerEnter(Collider CurrentLineObject)
    {

        var FadeOutLineScript = CurrentLineObject.GetComponent<FadeOutLineV01>();

        //_Copy the Line Objects's line positions
        var CurrentLineAttributes = CurrentLineObject.GetComponent<LineAttributesV01>();
        var VerticeTimes = CurrentLineAttributes.VectTime;
        var CurrentLineVertices = CurrentLineAttributes.Vertices;
        var TrailRenderer = CurrentLineObject.GetComponent<TrailRenderer>();

        //_Update all the verts with the new position
        var NumVerts = VerticeTimes.Length;
        if (CurrentWaypoint == 0)
        {
            TrailRenderer.Clear();

            while (CurrentWaypoint < VerticeTimes.Length)
            {
                this.transform.position = CurrentLineVertices[(VerticeTimes.Length - 1) - CurrentWaypoint];
                CurrentWaypoint++;
            } 
        }
        CurrentWaypoint = 0;


        LineStartTime = VerticeTimes[0];
        LineEndTime = VerticeTimes[NumVerts-1];
        var LineDrawTime = LineEndTime - LineStartTime;

        //VerticeTimes[0] = LineStartTime;
        //VerticeTimes[NumVerts - 1] = LineStartTime + LineDrawTime;
        

   

        FadeOutLineScript.enabled = true;
        //FadeOutLineScript.CurrentWaypoint = 0;
        FadeOutLineScript.LineStartTime = Time.deltaTime;
        FadeOutLineScript.LineEndTime = LineStartTime + LineDrawTime;


    }

}
