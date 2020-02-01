using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BottomMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float distToGround = 0;
    public float jumpforce;
    public float runspeed;
    public float accel;
    public bool activeHalf;
    float grav;
    public Feet feet;
    Rigidbody2D rb;

    Light2D selectionLlight;

    void Start()
    {
        selectionLlight = GetComponent<Light2D>();

        rb = GetComponent<Rigidbody2D>();
        accel = accel * rb.mass;
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        var jump = Input.GetButtonDown("Jump");
        if (activeHalf && jump && IsGrounded())
        {
            rb.velocity += Vector2.up * jumpforce;
        }
    }
    bool IsGrounded()
    {
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
    }

    public void ChangeLight(bool On)
    {
        selectionLlight.enabled = On;
    }
}
