using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TopMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float distToGround = 0;
    public float jumpforce;
    public float ladderSpeed;
    public float runspeed;
    public float groundFriction;
    public float accel;
    public float groundFrictionSpeedMult;
    public bool activeHalf;
    bool isClimbing;
    float grav;
    public BottomMovement bottom;
    public Feet feet;
    Rigidbody2D rb;

    int touchingLaddercount;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        grav = rb.gravityScale;
    }

    // Update is called once per frame
    void Switch()
    {
        activeHalf = !activeHalf;
        bottom.activeHalf = !bottom.activeHalf;
    }
    void Update()
    {
        var switchControls = Input.GetButtonDown("Switch");

        if (switchControls)
        {
            Switch();
        }

    }
    bool IsGrounded()
    {
        return feet.colliding;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            print("trigger enter");
            StartTouchingLadder();

        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            StopTouchingLadder();
        }
    }
    private void FixedUpdate()
    {
        var horizontalDir = Input.GetAxisRaw("Horizontal");
        var verticalDir = Input.GetAxisRaw("Vertical");
        if (activeHalf)
        {
            rb.AddForce(Vector2.right * accel * horizontalDir);
        }
        if (rb.velocity.x > runspeed)
        {
            rb.velocity = new Vector2(runspeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -runspeed)
        {
            rb.velocity = new Vector2(-runspeed, rb.velocity.y);
        }

        if ((touchingLaddercount > 0 && verticalDir == 1) && activeHalf)
        {
            isClimbing = true;
        }
        if (isClimbing && activeHalf)
        {
            rb.velocity = Vector2.up * verticalDir * ladderSpeed;
        }
    }
    void StartTouchingLadder()
    {
        touchingLaddercount++;
        rb.gravityScale = 0;
    }
    void StopTouchingLadder()
    {
        touchingLaddercount--;

        if (touchingLaddercount <= 0)
        {
            isClimbing = false;
            rb.gravityScale = grav;
        }
    }
}
