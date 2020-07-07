using UnityEngine;
using System.Collections;

public class StoreTrailData : MonoBehaviour
{
	private TrailRenderer tr;
	public bool ctrlKey;
    public Vector3[] positions;

	void Start()
	{
		tr = GetComponent<TrailRenderer>();
		tr.material = new Material(Shader.Find("Sprites/Default"));

		// A simple 2 color gradient with a fixed alpha of 1.0f.




	}

void Update()
{
		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.red, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
		);
		if (Input.GetMouseButton(1))
			tr.colorGradient = gradient;
		//tr.transform.position = new Vector3(Mathf.Sin(Time.time * 1.51f) * 7.0f, Mathf.Cos(Time.time * 1.27f) * 4.0f, 0.0f);

		//below is an attempt to get the positions of the trail vertexes
		const int MAX_POSITIONS = 100;
		Vector3[] TrailRecorded = new Vector3[MAX_POSITIONS];
  
        //void YourFunction ()
        //{

        int numberOfPositions = GetComponent<TrailRenderer>().GetPositions (TrailRecorded);
        if (Input.GetKeyDown("space"))
            //print (numberOfPositions);
            //new Vector3[TrailRecorded];
            positions[0] = TrailRecorded[3];
            print(positions[0]);
        //print ("This is being updated");
        //}   

    }
}
