using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWhenClicking : MonoBehaviour
{
    private GameObject _soi;

    void Awake()
    {
        _soi = GameObject.FindWithTag(Game.SoiTag);
        if (!_soi)
        {
            Debug.LogError("ShowWhenClicking can't find SOI tagged object");
        }
    }
    
    void Start()
    {
        _soi.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _soi.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _soi.SetActive(false);
        }
    }
}
