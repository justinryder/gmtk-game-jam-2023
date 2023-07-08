using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(TurnToFace))]
public class ShootRandomly : MonoBehaviour
{
    private Shooter _shooter;
    private TurnToFace _turnToFace;

    void Awake()
    {
        _shooter = GetComponent<Shooter>();
        if (!_shooter)
        {
            Debug.LogError("ShootRandomly requires a Shooter script on the same GameObject");
        }

        _turnToFace = GetComponent<TurnToFace>();
        if (!_turnToFace)
        {
            Debug.LogError("ShootRandomly requires a TurnToFace script on the same GameObject");
        }
    }

    void Update()
    {
        var asteroids = GameObject.FindGameObjectsWithTag(Game.AsteroidTag);
        if (asteroids.Length == 0)
        {
            // TODO: win condition, but do this in Game.cs
            Debug.Log("All Asteroids destroyed, no target found");
            return;
        }

        GameObject asteroid = asteroids[0];
        float asteroidDistance = (asteroids[0].transform.position - transform.position).magnitude;
        for (var i = 1; i < asteroids.Length; i++)
        {
            var distance = (asteroids[i].transform.position - transform.position).magnitude;
            if (distance < asteroidDistance)
            {
                asteroid = asteroids[i];
                asteroidDistance = distance;
                continue;
            }
        }

        if (_turnToFace.IsTurning)
        {
            if (asteroid.transform != _turnToFace.IsTurningTo)
            {
                _turnToFace.TurnTo(asteroid.transform, 30.0f);
            }
            return;
        }

        _shooter.Shoot();
        
        // Debug.Log("Turning to face and shoot");
        // Debug.Log(asteroid);

        _turnToFace.TurnTo(asteroid.transform, 30.0f);
    }
}
