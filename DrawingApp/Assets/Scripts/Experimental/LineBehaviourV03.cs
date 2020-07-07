// V01:
//Redraws the line when you press mouse button 2. 
//The code for this is a bit complicated because it was drawing a line between the end and start points.
// V02:

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehaviourV03 : MonoBehaviour
{

    public int CurrentWaypoint;
    private TrailRenderer tr;
    public float CreationTime;
    //public float PauseBeforeFadeOut = 6.0f;


    void Start()
    {
        CurrentWaypoint = 0;

        var CurrentLineAttributes = this.GetComponent<LineAttributesV01>();
        this.transform.position = CurrentLineAttributes.Vertices[CurrentWaypoint];
        var TrailRenderer = this.GetComponent<TrailRenderer>();
        TrailRenderer.emitting = true;


        //____________________________________________________________Set the gradient
        CreationTime = Time.fixedTime;
        tr = GetComponent<TrailRenderer>();
        tr.material = new Material(Shader.Find("Sprites/Default"));
        //print(CreationTime);

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        //float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys
            (
            new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
            );
        tr.colorGradient = gradient;



    }


    void Update()
    {

        var CurrentLineAttributes = this.GetComponent<LineAttributesV01>();
        var CurrentLineVertices = CurrentLineAttributes.Vertices;
        var TrailRenderer = this.GetComponent<TrailRenderer>();

        //____________________________________________________________Update the gradient
        Gradient gradient = new Gradient();
        gradient.SetKeys
            (
            new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.white, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey((CreationTime + 5.0f) - Time.fixedTime, 0.0f), new GradientAlphaKey(((CreationTime + 5.0f) - Time.fixedTime), 1.0f) }
            );
        tr.colorGradient = gradient;



        //This code stops a line being drawn between the end and start points.
        if (CurrentWaypoint == 0)
        {
            this.transform.position = CurrentLineVertices[CurrentWaypoint];
            CurrentWaypoint++;
            TrailRenderer.Clear();
        }

        else if (CurrentWaypoint == (CurrentLineVertices.Length -1))
        {
            var LastPosition = CurrentLineVertices[CurrentLineVertices.Length - 1];
            TrailRenderer.emitting = false;
            CurrentWaypoint = 0;
            this.enabled = false;
            this.transform.position = LastPosition;
        }

        else
        {
            TrailRenderer.emitting = true;
            this.transform.position = CurrentLineVertices[CurrentWaypoint];
            CurrentWaypoint++;
            //print(CurrentWaypoint);
        }

    }


}
