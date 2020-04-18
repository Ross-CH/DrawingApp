using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SticktoCursor : MonoBehaviour
{

    void Update()
    {
        RaycastHit camray;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out camray, float.PositiveInfinity))
            if (camray.collider != null)
                transform.position = camray.point;
    }
}
