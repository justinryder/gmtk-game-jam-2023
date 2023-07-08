using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToFace : MonoBehaviour
{
    public GameObject Crosshairs;

    private bool _turning;
    private Transform _endTransform;
    private float _rotationSpeed;

    public bool IsTurning => _turning;
    public Transform IsTurningTo => _endTransform;

    void Awake()
    {
        if (Crosshairs)
        {
            Crosshairs.SetActive(false);
        }
    }

    public void TurnTo(Transform target, float degreesPerSecond)
    {
        _endTransform = target;
        _rotationSpeed = degreesPerSecond;
        _turning = true;

        if (Crosshairs)
        {
            Crosshairs.SetActive(true);
        }
    }

    void Update()
    {
        if (!_turning)
        {
            return;
        }

        if (Crosshairs)
        {
            Crosshairs.transform.position = _endTransform.position;
        }

        var toEndPos = _endTransform.position - transform.position;

        var angleToEndRadians = Vector2.Dot((Vector2)transform.up, (Vector2)toEndPos.normalized);

        if (Mathf.Abs(angleToEndRadians - 1) < _rotationSpeed * Mathf.Deg2Rad * Time.deltaTime)
        {
            Debug.Log("Done turning to face");
            _turning = false;
            if (Crosshairs)
            {
                Crosshairs.SetActive(false);
            }
            return;
        }

        transform.Rotate(
            0,
            0,
            Mathf.Sign((angleToEndRadians - 1) * Mathf.Rad2Deg) * _rotationSpeed * Time.deltaTime
        );
    }
}
