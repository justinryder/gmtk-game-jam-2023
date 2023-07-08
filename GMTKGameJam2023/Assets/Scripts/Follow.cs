using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Target;
    public Vector3 Offset = Vector3.up * 0.65f;

    void Awake()
    {
        if (!Target)
        {
            Debug.LogError("Follow requires a Target to be assigned");
        }
    }
    
    void Update()
    {
        transform.position = Target.transform.position + Offset;
    }
}
