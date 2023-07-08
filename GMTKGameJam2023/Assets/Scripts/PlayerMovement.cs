using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private GameObject SOI;
    private GameObject Ship;
    //private GameObject[] Asteroid;
    public float distanceTotal;

    private float speed = -1.0f;

    void Awake()
    {
        SOI = GameObject.FindWithTag("SOI");
        if (!SOI)
        {
            Debug.LogError("PlayerMovement.cs requires the tag SOI to exist in the scene");
        }
        
        Ship = GameObject.FindWithTag("Ship");
        if (!Ship)
        {
            Debug.LogError("PlayerMovement.cs requires the tag Ship to exist in the scene");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 delta = SOI.transform.position - Ship.transform.position;

        Vector3 SOIpos = Camera.main.WorldToViewportPoint(SOI.transform.position);
        Vector3 Shippos = Camera.main.WorldToViewportPoint(SOI.transform.position);

        if (Mathf.Abs(SOIpos.x-Shippos.x)>0.5f) //Shortest distance is toward the object in the X Axis.
        {
           delta = new Vector3(delta.x * -1,delta.y,delta.z);

        }

        if (Mathf.Abs(SOIpos.y-Shippos.y)>0.5f) // Shortest distance is toward the object in the Y Axis.
        {
            delta = new Vector3(delta.x,delta.y * -1,delta.z);
        }

        distanceTotal = delta.magnitude;

        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position += delta.normalized * step;
        /*if (distanceTotal < 10)
        {
            transform.position += delta.normalized * step;
        }*/
        
    }
}
