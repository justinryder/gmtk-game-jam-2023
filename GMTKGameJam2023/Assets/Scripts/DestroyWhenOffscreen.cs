using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenOffscreen : MonoBehaviour
{
    private Camera _camera;
    
    void Awake()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOffscreen())
        {
            Destroy(gameObject);
        }
    }

    bool IsOffscreen()
    {
        var min = _camera.ScreenToWorldPoint(Vector3.zero);
        var max = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        return transform.position.x < min.x || transform.position.x > max.x || transform.position.y < min.y || transform.position.y > max.y;
    }
}
