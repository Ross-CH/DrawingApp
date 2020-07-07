using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopFrontStickToCursor : MonoBehaviour
{
    public GameObject DrawingSetupObject;
    public GameObject Cursor;
    public static float LoopDistance;//This value is derived from the CameraMove04 Script
    public //float Loopdistance;
    //public Vector3 targetPosition;

    void Update()
    {
        //Loopdistance = LoopDistance;
        transform.localPosition = new Vector3(Cursor.transform.localPosition.x, Cursor.transform.localPosition.y, Cursor.transform.localPosition.z + LoopDistance);
        //print(transform.localPosition.z);
        //print(LoopDistance);
    }
}
