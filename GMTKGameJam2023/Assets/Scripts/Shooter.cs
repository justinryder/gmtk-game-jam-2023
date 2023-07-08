using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletSpeed = 10.0f;

    private bool _debug = true;

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
        var bullet = GameObject.Instantiate(BulletPrefab);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        var rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.up * BulletSpeed;
    }
}
