using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    private HealthBar HealthBar;

    private const int _maxHealth = 10;
    private int _health = _maxHealth;

    void Awake()
    {
        HealthBar = GameObject.FindWithTag(Game.HealthBarTag)?.GetComponent<HealthBar>();
        if (!HealthBar)
        {
            Debug.LogError("ShipHealth could not find a HealthBar tagged game object with HealthBar script");
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp("z"))
        {
            OnHit();
        }
    }

    public void OnHit()
    {
        // Debug.Log("Ship hit by asteroid, -1 hp");
        _health -= 1;

        if (HealthBar)
        {
            HealthBar.SetHealth((float)_health / (float)_maxHealth);
        }

        if (_health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // TODO: show win screen on ship death
        // Debug.Log("Ship was destroyed! Show win screen");
        // gameObject.SetActive(false);

        var game = GameObject.FindWithTag("Game")?.GetComponent<Game>();
        if (game)
        {
            game.Win();
        }
    }
}
