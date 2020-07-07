using UnityEngine;
using System.Collections;

public class TrailColourSetV03 : MonoBehaviour
{
    private TrailRenderer tr;
    public float LineStartTime;
    public float LineEndTime;

    public float PauseBeforeFadeOut = 0.4f;


    void Start()
    {
        LineStartTime = Time.fixedTime;
        tr = GetComponent<TrailRenderer>();
        tr.material = new Material(Shader.Find("Sprites/Default"));
        //print(CreationTime);

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        //float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys
            (
            new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.white, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
            );
        tr.colorGradient = gradient;
    }

    void Update()
    {
        Gradient gradient = new Gradient();
        gradient.SetKeys
            (
            new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.white, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(LineStartTime + PauseBeforeFadeOut - Time.fixedTime, 0.0f), new GradientAlphaKey((LineEndTime + PauseBeforeFadeOut - Time.fixedTime), 1.0f) }
            );
        tr.colorGradient = gradient;
    }
}