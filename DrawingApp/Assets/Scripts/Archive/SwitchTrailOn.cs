using UnityEngine;

public class SwitchTrailOn: MonoBehaviour {
//public GameObject AddObject;

void Update(){
	Event m_Event = Event.current;
	TrailRenderer TrailRender = GetComponent<TrailRenderer>();

		if (Input.GetMouseButton(0))
			TrailRender.emitting = true;
		else
			TrailRender.emitting = false;
			//Instantiate(AddObject, transform.position, transform.rotation);
	}


}
