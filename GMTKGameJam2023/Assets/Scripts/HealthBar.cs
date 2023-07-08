using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject Foreground;

    void Awake()
    {
        if (!Foreground)
        {
            Debug.LogError("HealthBar requires the Foreground child be pointed to");
        }
    }

    public void SetHealth(float healthRatio)
    {
        if (healthRatio < 0)
        {
            return;
        }
        // TODO: lerp this, add shake effect when taking damage
        var scale = Foreground.transform.localScale;
        scale.x = healthRatio;
        Foreground.transform.localScale = scale;
        Foreground.transform.localPosition = new Vector3((1 - healthRatio) / -2, 0, 0);
    }
}
