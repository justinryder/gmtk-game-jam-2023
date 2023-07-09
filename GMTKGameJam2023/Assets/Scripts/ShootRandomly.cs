using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(TurnToFace))]
public class ShootRandomly : MonoBehaviour
{
    private Shooter _shooter;
    private TurnToFace _turnToFace;
    public AudioClip ShootSound;

    private float TurnSpeed = 100.0f;

    private bool _enabled = true;

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
        if (!_enabled)
        {
            return;
        }

        var asteroids = GameObject.FindGameObjectsWithTag(Game.AsteroidTag);
        if (asteroids.Length == 0)
        {
            // Debug.Log("All Asteroids destroyed, no target found");
            var game = GameObject.FindWithTag("Game")?.GetComponent<Game>();
            if (game)
            {
                game.Lose();
                // _enabled = false; // stop shooting randomly
                Destroy(_turnToFace.Crosshairs);
                Destroy(_turnToFace);
                Destroy(this);
            }
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
                _turnToFace.TurnTo(asteroid.transform, TurnSpeed);
            }
            return;
        }

        _shooter.Shoot();
        
        if (ShootSound)
        {
            AudioSource.PlayClipAtPoint(ShootSound, transform.position);
        }
        
        // Debug.Log("Turning to face and shoot");
        // Debug.Log(asteroid);

        _turnToFace.TurnTo(asteroid.transform, TurnSpeed);
    }
}
