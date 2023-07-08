using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ksibtestmovement : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Ship";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            myRigidBody.velocity = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
            myRigidBody.velocity = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.S) == true)
        {
            myRigidBody.velocity = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.D) == true)
        {
            myRigidBody.velocity = Vector2.right;
        }
        
    }
}
