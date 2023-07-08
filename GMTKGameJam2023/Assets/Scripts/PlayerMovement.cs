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
        distanceTotal = delta.magnitude;

        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        if (distanceTotal < 2)
        {
            transform.position += delta.normalized * step;
        }
        
    }
}
