using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    private int _health = 5;

    public void OnHit()
    {
        Debug.Log("Ship hit by asteroid, -1 hp");
        _health -= 1;

        if (_health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // TODO: show win screen on ship death
        Debug.Log("Ship was destroyed! Show win screen");
        Destroy(gameObject);
    }
}
