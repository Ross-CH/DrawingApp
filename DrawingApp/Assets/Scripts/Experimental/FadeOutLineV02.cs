// V01:
//Redraws the line when you press mouse button 2. 
//The code for this is a bit complicated because it was drawing a line between the end and start points.
// V02:

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeOutLineV02 : MonoBehaviour
{

    //public int CurrentWaypoint;
    private TrailRenderer tr;
    public float LineStartTime = 0.0f;
    public float LineEndTime = 0.0f;
    public float LineDrawTime = 0.0f;





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

       
       var LineStartAlpha = LineStartTime + 1.0f - Time.fixedTime;
        var LineEndAlpha = LineEndTime + 1.0f - Time.fixedTime;
        
        print (LineStartAlpha);
        print(LineEndAlpha);
        print("");



        Gradient NewGradient = new Gradient();
        NewGradient.SetKeys
            (
            new GradientColorKey[] { new GradientColorKey(CKey0.color, 0.0f), new GradientColorKey(CKey1.color, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(LineStartAlpha, 1.0f), new GradientAlphaKey(LineEndAlpha, 0.0f) }
            );

        TrailRenderer.colorGradient = NewGradient;

      
        if (LineEndAlpha < 0)
        {
            this.enabled = false;
        }
       


    }


}
