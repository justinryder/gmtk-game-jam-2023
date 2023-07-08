using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DecoShip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, -90);
        // transform.position = new Vector3(Random.Range(-Screen.width, Screen.width), Random.Range(-Screen.height, Screen.height), 0);
        float duration = Random.Range(4f, 10f);

        // get the visible width of the main camera
        float camHeight = Camera.main.orthographicSize * 2;
        float camWidth = camHeight * Camera.main.aspect;

        transform.DOMoveX(camWidth, duration).SetEase(Ease.InOutSine).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
