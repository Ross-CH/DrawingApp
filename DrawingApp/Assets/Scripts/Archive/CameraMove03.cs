using UnityEngine;
using System.Collections;

public class CameraMove03 : MonoBehaviour {
	public float MoveSpeed;
	//public float SquidTorque;

	void Start (){ 
	}

	void Update () {

		transform.localPosition = new Vector3 (transform.localPosition.x,transform.localPosition.y,transform.localPosition.z - MoveSpeed);
	}
}