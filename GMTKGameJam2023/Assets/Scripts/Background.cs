using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Vector3 bgPos;
    public float rotationSpeed = 1f;
    public float rotationDirection = 1f;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (rotationSpeed > 0)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        else if (rotationSpeed < 0)
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }
}
