using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerClickToPlaceObject : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -Camera.main.transform.position.z; // compensates for the z-position of the camera.
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = worldPos;
        }
    }
}
