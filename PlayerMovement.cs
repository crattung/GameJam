using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

     public float movementspeed = 5f;
     public Rigidbody2D rb;
    public Animator animator;


    Vector2 movement;





    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);


    }

     void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementspeed * Time.fixedDeltaTime);
    }







}
