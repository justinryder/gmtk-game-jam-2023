    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesiredPositionforShip : MonoBehaviour
{

    private GameObject SOI;
    private GameObject Ship;
    private GameObject[] Asteroids;
    private float distanceTotal;

    private float speed = -3f;
    private float centerForceMagnitude = 0;
    

    void Awake()
    {
        SOI = GameObject.FindWithTag("SOI");
        if (!SOI)
        {
            Debug.LogError("DesiredPositionforShip.cs requires the tag SOI to exist in the scene");
        }
        
        Ship = GameObject.FindWithTag(Game.ShipTag);
        if (!Ship)
        {
            Debug.LogError("DesiredPositionforShip.cs requires the tag Ship to exist in the scene");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");


        GameObject asteroid = asteroids[0];
        float asteroidDistance = (asteroids[0].transform.position - Ship.transform.position).magnitude;
        for (var i = 1; i < asteroids.Length; i++)
        {
            var distance = (asteroids[i].transform.position - Ship.transform.position).magnitude;
            if (distance < asteroidDistance)
            {
                asteroid = asteroids[i];
                asteroidDistance = distance;
                continue;
            }
        }

        var deltaPosition = asteroid.transform.position - Ship.transform.position;
        transform.position = Ship.transform.position - deltaPosition;
        
        // GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        // Vector3 position = Vector3.zero;

        // foreach (GameObject Asteroid in Asteroids)
        // {
        //     if (Asteroid == null)
        //     {
        //         Debug.LogError("An Asteroid is null");
        //         continue;
        //     }
        //     Vector3 delta = Asteroid.transform.position - Ship.transform.position;
        //     float distance = delta.magnitude;

        //     Vector3 AsteroidPos = Camera.main.WorldToViewportPoint(Asteroid.transform.position);
        //     Vector3 Desiredpos = Camera.main.WorldToViewportPoint(Ship.transform.position);

        //     // if (Mathf.Abs(AsteroidPos.x - Desiredpos.x) > 0.5f) //Shortest distance is toward the object in the X Axis.
        //     // {
        //     //     delta.x = delta.x * -1;
        //     // }

        //     // if (Mathf.Abs(AsteroidPos.y - Desiredpos.y) > 0.5f) // Shortest distance is toward the object in the Y Axis.
        //     // {
        //     //     delta.y = delta.y * -1;
        //     // }

        //     //float step = speed * Time.deltaTime;
        //     // float step = speed * Time.deltaTime / distance;

        //     position += delta.normalized * step;
        // }

        // // Add a force that pushes DesiredPOS towards the center of the screen
        // // Tried to promote DesiredPOS to head towards the center of screen rather than edges.
        // Vector3 center = new Vector3(0.5f, 0.5f, position.z);
        // Vector3 centerInWorld = Camera.main.ViewportToWorldPoint(center);
        // Vector3 toCenter = centerInWorld - position;
        // Vector3 centerForce = toCenter.normalized * centerForceMagnitude;

        // centerForce.z = 0; // Prevent movement in the Z direction

        // transform.position = position;
    }
}
