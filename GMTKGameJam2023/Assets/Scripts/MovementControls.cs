using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementControls : MonoBehaviour
{
    public float Speed = 5.0f;

    private Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") * Speed * Time.deltaTime));
    }
}
