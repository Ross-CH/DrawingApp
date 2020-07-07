using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToObject : MonoBehaviour
{
public GameObject target;
    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Sphere");
        Vector3 targetPosition = target.transform.position;
        transform.position = targetPosition;
    }
}
