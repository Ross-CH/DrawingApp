using UnityEngine;
using System.Collections;

public class TrailSetColourBasic : MonoBehaviour
{
	private TrailRenderer tr;
	public bool ctrlKey;

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
		//tr.transform.position = new Vector3(Mathf.Sin(Time.time * 1.51f)
	}
}