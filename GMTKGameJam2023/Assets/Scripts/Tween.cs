using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tween : MonoBehaviour
{

    public bool fromEdge = true;
    public float duration = 0.7f;

    public float delay = 0.7f;

    void Start()
    {

        if (fromEdge)
        {
            transform.DOMoveX(-Screen.width, duration).From().SetEase(Ease.InOutSine).SetDelay(delay);
        }
        else
        {
            transform.DOMoveX(Screen.width, duration).From().SetEase(Ease.InOutSine).SetDelay(delay);
        }
    }
}
