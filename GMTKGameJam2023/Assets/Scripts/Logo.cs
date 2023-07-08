using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Logo : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveX(-Screen.width, 0.7f).From();
    }
}
