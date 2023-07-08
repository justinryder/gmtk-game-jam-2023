using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private GameObject SOI;
    private GameObject Ship;
    private GameObject DesiredPOS;
    
    //private GameObject[] Asteroid;
    public float distanceTotal;

    private float speed = -2.0f;
    

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
        DesiredPOS = GameObject.FindWithTag("DesiredPOS");
        if (!DesiredPOS)
        {
            Debug.LogError("PlayerMovement.cs requires the tag DesiredPOS to exist in the scene");
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 delta =  SOI.transform.position - DesiredPOS.transform.position;
        float distance = delta.magnitude;

        Vector3 SOIpos = Camera.main.WorldToViewportPoint(SOI.transform.position);
        Vector3 Desiredpos = Camera.main.WorldToViewportPoint(DesiredPOS.transform.position);
        Vector3 Shippos = Camera.main.WorldToViewportPoint(Ship.transform.position);

        Vector3 Shipdelta = DesiredPOS.transform.position - Ship.transform.position;




        if (Mathf.Abs(SOIpos.x-Desiredpos.x)>0.5f) //Shortest distance is toward the object in the X Axis.
        {
           delta.x = delta.x * -1;
           //Debug
        }

        if (Mathf.Abs(SOIpos.y-Desiredpos.y)>0.5f) // Shortest distance is toward the object in the Y Axis.
        {
            delta.y = delta.y * -1;
        }

        if (Mathf.Abs(Desiredpos.x-Shippos.x)<0.5f) //Shortest distance is toward the object in the X Axis.
        {
           Shipdelta.x = Shipdelta.x * -1;
           //Debug
        }

        if (Mathf.Abs(Desiredpos.y-Shippos.y)<0.5f) // Shortest distance is toward the object in the Y Axis.
        {
            Shipdelta.y = Shipdelta.y * -1;
        }


        distanceTotal = delta.magnitude;

        float step = speed * Time.deltaTime;

        transform.position += delta.normalized * step;

        Ship.transform.position += Shipdelta.normalized * speed * Time.deltaTime;


    }
}
