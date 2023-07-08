using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GravityWell : MonoBehaviour
{
    public float Gravity = 5.0f;

    public string InfluenceTag = "Asteroid";

    private List<Rigidbody2D> _asteroids = new List<Rigidbody2D>();

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        foreach (var asteroid in _asteroids)
        {
            var deltaPosition = transform.position - asteroid.transform.position;
            asteroid.AddForce((deltaPosition.normalized / deltaPosition.magnitude) * Gravity * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != InfluenceTag)
        {
            return;
        }

        _asteroids.Add(other.GetComponent<Rigidbody2D>());
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != InfluenceTag)
        {
            return;
        }

        _asteroids.Remove(other.GetComponent<Rigidbody2D>());
    }
}
