using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Gravity Planet;
    public float moveSpeed;
    public bool Turbo;
    public bool TurningRight;
    public bool TurningLeft;   

    private float constantSpeed;
    private float idleSpeed = 5F;
    private float turboSpeed = 8F;
    private Transform playerTransform;
    private Vector3 moveDirection;

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        constantSpeed = idleSpeed; //constant speed is 0F at start.  

        playerTransform = transform;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * constantSpeed); //Move forward automatically

        if (Input.GetKey(KeyCode.LeftShift)) //Enabling turbo on hold
        {
            Turbo = true;
            constantSpeed = turboSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) //Disabling turbo on release
        {
            Turbo = false;
            constantSpeed = idleSpeed;
        }

        if (Input.GetKey(KeyCode.D)) 
        {
            TurningLeft = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            TurningRight = false;
        }
    }

    void FixedUpdate()
    {
        if (Planet)
        {
            Planet.Attract(playerTransform);
        }

    }
}