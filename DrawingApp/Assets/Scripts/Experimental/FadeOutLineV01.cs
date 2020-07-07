// V01:
//Redraws the line when you press mouse button 2. 
//The code for this is a bit complicated because it was drawing a line between the end and start points.
// V02:

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeOutLineV01 : MonoBehaviour
{

    //public int CurrentWaypoint;
    private TrailRenderer tr;
    public float LineStartTime;
    public float LineEndTime;
    //public float PauseBeforeFadeOut = 6.0f;


  


    void Update()
    {

        var CurrentLineAttributes = this.GetComponent<LineAttributesV01>();
        var CurrentLineVertices = CurrentLineAttributes.Vertices;

        var TrailRenderer = this.GetComponent<TrailRenderer>();

        
        //Get the colour & alpha values of the gradient keys stored in the LineAttributes script

        Gradient gradient = TrailRenderer.colorGradient;
        var AlphaKeys = gradient.alphaKeys;
        var ColourKeys = gradient.colorKeys;
        
        var CKey0 = ColourKeys[0];
        var CKey1 = ColourKeys[1];
        var AKey0 = AlphaKeys[0];
        var AKey1 = AlphaKeys[1];

        //var Color0 = CKey0.color;
        //var Color1 = CKey1.color;
        //var Alpha0 = AKey0.alpha;
        //var Alpha1 = AKey1.alpha;

        //Alpha0 = Alpha0 - 0.00002f;
        //Alpha1 = Alpha1 - 0.00002f;
       
        //print (CKey0);


        Gradient NewGradient = new Gradient();
        NewGradient.SetKeys
            (
            new GradientColorKey[] { new GradientColorKey(CKey0.color, 0.0f), new GradientColorKey(CKey1.color, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(LineEndTime + 7.0f - Time.fixedTime, 0.0f), new GradientAlphaKey((LineStartTime + 7.0f - Time.fixedTime), 1.0f) }
            );

        TrailRenderer.colorGradient = NewGradient;




    }


}
