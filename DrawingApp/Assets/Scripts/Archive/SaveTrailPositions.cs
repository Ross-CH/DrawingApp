using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrailPositions : MonoBehaviour
{
    // Start is called before the first frame update
 
void Update()
	{
		const int MAX_POSITIONS = 100;
		Vector3[] TrailRecorded = new Vector3[MAX_POSITIONS];
		//print ("This is being updated");
		//void YourFunction ()
		//{

		int numberOfPositions = GetComponent<TrailRenderer>().GetPositions (TrailRecorded);
		if (Input.GetKeyDown(KeyCode.Space))
			//print ("SpaceKeyPressed");
			print (numberOfPositions);
			//print ("This is being updated");
	}   


}
