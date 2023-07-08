using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private static readonly float[] Sizes = new[]
    {
        0.2f,
        0.5f,
        1.0f
    };

    public static readonly int MinSize = 0;
    public static readonly int MaxSize = Sizes.Length - 1;

    private int _size;

    public void SetSize(int size)
    {
        _size = size;
        transform.localScale = Vector2.one * Sizes[size];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Game.AsteroidTag)
        {
            // OnHit(collision);
        }

        if (collision.gameObject.tag == Game.BulletTag)
        {
            Destroy(collision.gameObject);
            OnHit(collision);
        }

        if (collision.gameObject.tag == Game.ShipTag)
        {
            Debug.Log("game over! somebody should probably implement this lol");
            var shipHealth = collision.gameObject.GetComponent<ShipHealth>();
            if (shipHealth)
            {
                shipHealth.OnHit();
            }
            
            OnHit(collision);
        }
    }

    void OnHit(Collision2D collision)
    {
        if (_size == 0)
        {
            Destroy(gameObject);
            return;
        }

        var gameGameObject = GameObject.FindWithTag("Game");
        if (!gameGameObject)
        {
            Debug.LogError("No GameObject tagged Game in scene");
        }
        var game = gameGameObject.GetComponent<Game>();
        if (!game)
        {
            Debug.LogError("Game GameObject has no Game script");
        }

        // TODO: spawn 2 asteroids at -1 size that move in opposite directions tangent to the angle of impact

        var contact = collision.GetContact(0);

        var tangent = Vector2.Perpendicular(contact.normal);

        var size = Sizes[_size];

        game.SpawnAsteroid(
            (Vector2)transform.position - contact.normal * size + tangent * size,
            _size - 1,
            tangent * contact.normalImpulse
        );
        game.SpawnAsteroid(
            (Vector2)transform.position - contact.normal * size - tangent * size,
            _size - 1,
            -tangent * contact.normalImpulse
        );

        Destroy(gameObject);
    }
}
