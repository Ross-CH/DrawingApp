using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToLoopBackCursor : MonoBehaviour
{
public GameObject target;
    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("LoopBackCursor");
        Vector3 targetPosition = target.transform.position;
        transform.position = targetPosition;
    }
}
