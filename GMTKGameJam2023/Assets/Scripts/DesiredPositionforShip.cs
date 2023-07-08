using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesiredPositionforShip : MonoBehaviour
{

    private GameObject SOI;
    private GameObject DesiredPOS;
    private GameObject[] Asteroids;
    public float distanceTotal;

    private float speed = -2.0f;
    

    void Awake()
    {
        SOI = GameObject.FindWithTag("SOI");
        if (!SOI)
        {
            Debug.LogError("DesiredPositionforShip.cs requires the tag SOI to exist in the scene");
        }
        
        DesiredPOS = GameObject.FindWithTag("DesiredPOS");
        if (!DesiredPOS)
        {
            Debug.LogError("DesiredPositionforShip.cs requires the tag DesiredPOS to exist in the scene");
        }
        

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        
        foreach (GameObject Asteroid in Asteroids)
        {
            if (Asteroid == null)
            {
                Debug.LogError("An Asteroid is null");
                continue;
            }
            Vector3 delta = Asteroid.transform.position - DesiredPOS.transform.position;
            float distance = delta.magnitude;

            Vector3 AsteroidPos = Camera.main.WorldToViewportPoint(Asteroid.transform.position);
            Vector3 Desiredpos = Camera.main.WorldToViewportPoint(DesiredPOS.transform.position);

            if (Mathf.Abs(AsteroidPos.x - Desiredpos.x) > 0.5f) //Shortest distance is toward the object in the X Axis.
            {
                delta.x = delta.x * -1;
            }

            if (Mathf.Abs(AsteroidPos.y - Desiredpos.y) > 0.5f) // Shortest distance is toward the object in the Y Axis.
            {
                delta.y = delta.y * -1;
            }

            //float step = speed * Time.deltaTime;
            float step = speed * Time.deltaTime / distance;
            transform.position += delta.normalized * step;
        }

    }
}
