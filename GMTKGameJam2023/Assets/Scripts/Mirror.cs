using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x < 0.0f)
            {
                pos.x = 1.0f; // right
            }
            else if (pos.x > 1.0f)
            {
                pos.x = 0.0f; // left
            }

            if (pos.y < 0.0f)
            {
                pos.y = 1.0f; // top
            }
            else if (pos.y > 1.0f)
            {
                pos.y = 0.0f; // bottom
            }

            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }
}
