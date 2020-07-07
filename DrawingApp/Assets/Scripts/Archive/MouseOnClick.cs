using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOnClick : MonoBehaviour
{
public GameObject brush001;
public GameObject Cursor;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            Instantiate(brush001, Cursor.transform.position, transform.rotation);
        //brush001.transform.position = (0.01,0.01,0.01);
    }
}
