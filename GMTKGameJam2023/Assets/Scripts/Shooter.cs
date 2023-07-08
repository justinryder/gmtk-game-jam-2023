using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletSpeed = 10.0f;
    public float BulletSpawnDistance = 0.5f;
    public float ShootDelay = 1.0f;

    private bool _debug = true;
    private float _lastShotTime;

    void Awake()
    {
        if (!BulletPrefab)
        {
            Debug.LogError("Shooter requires a BulletPrefab be assigned");
        }
    }

    void Update()
    {
        if (Input.GetKeyUp("space") && _debug)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (_lastShotTime + ShootDelay >= Time.time)
        {
            return;
        }

        _lastShotTime = Time.time;

        var bullet = GameObject.Instantiate(BulletPrefab);
        bullet.transform.position = transform.position + transform.up * BulletSpawnDistance;
        bullet.transform.rotation = transform.rotation;
        var rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.up * BulletSpeed;
    }
}
