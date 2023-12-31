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
        if (!Crosshairs)
        {
            Crosshairs = GameObject.FindWithTag(Game.CrosshairTag);
        }

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
        if (!_turning || Time.timeScale == 0)
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
            // Debug.Log("Done turning to face");
            _turning = false;
            if (Crosshairs)
            {
                Crosshairs.SetActive(false);
            }
            return;
        }

        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.totalTorque = 0;

        var turnDirection = Vector2.Dot((Vector2)transform.right, (Vector2)toEndPos.normalized);

        transform.Rotate(
            0,
            0,
            -Mathf.Sign(turnDirection) * _rotationSpeed * Time.deltaTime
        );
    }
}
