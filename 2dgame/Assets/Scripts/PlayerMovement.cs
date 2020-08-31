using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]//makes sure the object this script is being added to has a rigidbody2d component
public class PlayerMovement : MonoBehaviour
{

    public float movementspeed = 5f;
    private Rigidbody2D rb; //making them private cus they wont be accessed through outside code not inspector
    private Animator animator; // same ^
    private Camera _mainCam;


    Vector2 movement;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _mainCam = Camera.main;
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(animator)//checks if animator is assigned/found using getcomponent
        {
            
            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
            animator.SetFloat("speed", movement.sqrMagnitude);
            animator.SetBool("Walking", movement.sqrMagnitude > 0);
        }


    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementspeed * Time.fixedDeltaTime);
    }







}
