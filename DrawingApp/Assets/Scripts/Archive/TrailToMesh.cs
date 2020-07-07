using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailToMesh : MonoBehaviour
{

    public bool left;
    // Start is called before the first frame update
    void Update()
    {
        left = Input.GetKey(KeyCode.A);

        TrailRenderer TrailRenderComponent = GetComponent<TrailRenderer>();

        //if (left == true)
            //TrailRenderer(mesh, Camera, useTransform);

    }

   
}
