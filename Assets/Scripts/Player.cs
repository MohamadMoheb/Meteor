using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Gravity Planet;
    public float moveSpeed;
    public bool GameStarted;
    public bool EngineState;
    public bool Turbo;
    public bool TurningRight;
    public bool TurningLeft;

    private float constantSpeed;
    private float idleSpeed = 5F;
    private float turboSpeed = 10F;
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
        if (Input.GetKeyDown(KeyCode.E)) //Toggle EngineState
        {
            if (EngineState == false) //Turn Engine on
            {
                EngineState = true;
                GameStarted = true;
                Debug.Log("Game Started");
            }

            else
            {
                EngineState = false; //Turn Engine off
            }
        }
        if (GameStarted == true)
        {
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
                Vector3 rotationToAdd = new Vector3(0, 1, 0);
                transform.Rotate(rotationToAdd);
                TurningRight = true;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                TurningRight = false;
            }

            if (Input.GetKey(KeyCode.A)) 
            {
                Vector3 rotationToAdd = new Vector3(0, -1, 0);
                transform.Rotate(rotationToAdd);
                TurningLeft = true;
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
            TurningLeft = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (EngineState == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * constantSpeed); //Move forward automatically
        }

        if (Planet)
        {
            Planet.Attract(playerTransform);
        }

    }
}