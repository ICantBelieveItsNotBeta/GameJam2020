using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TopMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float distToGround = 0;
    public float jumpforce;
    public float ladderSpeed;
    public float runspeed;
    public float accel;
    public bool activeHalf;
    bool isClimbing;
    float grav;
    public BottomMovement bottom;
    public Feet feet;
    Rigidbody2D rb;

    private Animator _animator;


    Light2D selectionLlight;

    int touchingLaddercount;

    void Start()
    {
        selectionLlight = GetComponentInChildren<Light2D>();


        if (bottom == null)
        {
            print("ERROR: your top needs a bottom!!!");
        }
        rb = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        grav = rb.gravityScale;

        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Switch()
    {
        activeHalf = !activeHalf;
        bottom.activeHalf = !bottom.activeHalf;

        ChangeLight(activeHalf);
        bottom.ChangeLight(bottom.activeHalf);
    }
    void Update()
    {
        var switchControls = Input.GetButtonDown("Switch");

        if (switchControls)
        {
            Switch();
        }

        var direction = 1f;
        if (rb.velocity.x != 0f)
        {
            direction = (Mathf.Abs(rb.velocity.x) / rb.velocity.x);
        }
        _animator.transform.localScale = new Vector3(direction * Mathf.Abs(_animator.transform.localScale.x), _animator.transform.localScale.y, 1);
        GetComponent<SpriteRenderer>().flipX = direction == -1;
        _animator.SetFloat("HorizontalVelocity", Mathf.Abs(rb.velocity.x));
        _animator.SetBool("isGrounded", IsGrounded());
    }
    bool IsGrounded()
    {
        return feet.colliding;
    }

    private void FixedUpdate()
    {
        var horizontalDir = Input.GetAxisRaw("Horizontal");
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
    }
    public void ChangeLight(bool On)
    {
        selectionLlight.enabled = On;
    }
}
