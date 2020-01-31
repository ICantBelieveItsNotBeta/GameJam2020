using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TopMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float distToGround = 0;
    public float jumpforce;
    public float runspeed;
    public float groundFriction;
    public float accel;
    public float groundFrictionSpeedMult;
    public bool activeHalf;
    bool jumping;
    float grav;
    public BottomMovement bottom;
    public Feet feet;
    Rigidbody2D rb;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
    }

    // Update is called once per frame
    void Switch()
    {
        activeHalf = !activeHalf;
        bottom.activeHalf = !bottom.activeHalf;
    }
    void Update()
    {
        var jump = Input.GetAxisRaw("Jump") == 1;
        var switchControls = Input.GetButtonDown("Switch");

        if (switchControls)
        {
            Switch();
        }

        if (activeHalf && jump && IsGrounded())
        {
            if (!jumping)
            {
                rb.velocity += Vector2.up * jumpforce;
                jumping = true;
            }
        }
        if (!jump)
        {
            jumping = false;
        }
    }
    bool IsGrounded()
    {
        //print(feet.colliding);
        return feet.colliding;
    }
    private void FixedUpdate()
    {
        var dir = Input.GetAxisRaw("Horizontal");
        if (activeHalf)
        {
            rb.AddForce(Vector2.right * accel * dir);
        }
        if (rb.velocity.x > runspeed)
        {
            rb.velocity = new Vector2(runspeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -runspeed)
        {
            rb.velocity = new Vector2(-runspeed, rb.velocity.y);
        }
        if (IsGrounded())
        {
            rb.AddForce(-Vector2.right * (float)Math.Tanh(groundFrictionSpeedMult * rb.velocity.x) * groundFriction);
        }
    }
}
