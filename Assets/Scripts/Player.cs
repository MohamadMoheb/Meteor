using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Gravity Planet;
    public float moveSpeed;

    private float constantSpeed = 5F;
    private Transform playerTransform;
    private Vector3 moveDirection;


    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        playerTransform = transform;
    }

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetKey(KeyCode.LeftShift)) //Turbo
        {
            constantSpeed = constantSpeed * 2;
            Debug.Log("Left Shift key is being pressed");
        }

        transform.Translate(Vector3.forward * Time.deltaTime * constantSpeed); //Move forward automatically
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

        if (Planet)
        {
            Planet.Attract(playerTransform);
        }
    }
}