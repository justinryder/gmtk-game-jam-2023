using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private GameObject Ship;
    private GameObject DesiredPOS;
    
    private float distanceTotal;

    private float speed = -80f;

    private Rigidbody2D _rigidbody;
    

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
        _rigidbody = GetComponent<Rigidbody2D>();
        if (!_rigidbody)
        {
            Debug.LogError("PlayerMovement must have a Rigidbody2D");
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
        
        // if (Shipdelta.magnitude > .3)
        {
            _rigidbody.AddForce(Shipdelta.normalized * step);
            // transform.position += Shipdelta.normalized * step;
        }




    }
}
