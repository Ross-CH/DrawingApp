using UnityEngine;
using System.Collections;

public class TrailColourSetV02 : MonoBehaviour
{
    //private TrailRenderer tr;
    //Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    void Start()
    {
        var tr = this.GetComponent<TrailRenderer>();
        //gradient = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.blue;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.red;
        colorKey[1].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 0.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.0f;
        alphaKey[1].time = 1.0f;

        tr.colorGradient.SetKeys(colorKey, alphaKey);

        // What's the color at the relative time 0.25 (25 %) ?
        Debug.Log(tr.colorGradient.Evaluate(0.25f));
    }



    void Update()
    {
    // this links shows how to update the gradient without needing to use 'Update' https://docs.unity3d.com/2020.2/Documentation/ScriptReference/Gradient.html
    }
}