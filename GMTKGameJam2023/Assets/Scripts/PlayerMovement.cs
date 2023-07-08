using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private GameObject Ship;
    private GameObject DesiredPOS;
    
    public float distanceTotal;

    private float speed = -3.0f;
    

    void Awake()
    {
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
        

        Vector3 Desiredpos = Camera.main.WorldToViewportPoint(DesiredPOS.transform.position);
        Vector3 Shippos = Camera.main.WorldToViewportPoint(Ship.transform.position);

        Vector3 Shipdelta = DesiredPOS.transform.position - Ship.transform.position;

        if (Mathf.Abs(Desiredpos.x-Shippos.x)<0.5f) //Shortest distance is toward the object in the X Axis.
        {
           Shipdelta.x = Shipdelta.x * -1;
           //Debug
        }

        if (Mathf.Abs(Desiredpos.y-Shippos.y)<0.5f) // Shortest distance is toward the object in the Y Axis.
        {
            Shipdelta.y = Shipdelta.y * -1;
        }


        float step = speed * Time.deltaTime;

        transform.position += Shipdelta.normalized * speed * Time.deltaTime;
        //Ship.transform.LookAt(DesiredPOS.transform.position * Time.deltaTime * speed);
        //Ship.transform.rotation = Quaternion.Slerp(Quaternion.Euler(DesiredPOS.transform.position.x, 0f,0f), Quaternion.LookRotation(DesiredPOS.transform.position), 2f * Time.deltaTime);

        var angle = Mathf.Atan2(Shipdelta.y, Shipdelta.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


    }
}
