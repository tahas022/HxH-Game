using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f; //character speed to be adjusted through engine if you like
    public Rigidbody2D rb; //applies physics to game body
    public Animator animator;
    
    Vector2 movement;


    //update is called once per frame
    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal"); 
       movement.y = Input.GetAxisRaw("Vertical");     

       animator.SetFloat("Horizontal", movement.x);
       animator.SetFloat("Vertical", movement.y);
       animator.SetFloat("Speed", movement.sqrMagnitude);  
    }

    //works same way as update, but it's executed on the fixed timer so perfect for physics
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime); 
    }
}
