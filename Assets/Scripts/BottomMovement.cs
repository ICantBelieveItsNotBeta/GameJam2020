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
    private Animator _animator;

    void Start()
    {
        selectionLlight = GetComponentInChildren<Light2D>();

        rb = GetComponent<Rigidbody2D>();
        accel = accel * rb.mass;
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var jump = Input.GetButtonDown("Jump");
        if (activeHalf && jump && IsGrounded())
        {
            rb.velocity += Vector2.up * jumpforce;
        }
        var direction = 1f;
        if (rb.velocity.x != 0f)
        {
            direction = (Mathf.Abs(rb.velocity.x) / rb.velocity.x);
        }
        _animator.transform.localScale = new Vector3(direction * Mathf.Abs(_animator.transform.localScale.x), _animator.transform.localScale.y, 1);
        GetComponent<SpriteRenderer>().flipX = direction == -1;
        _animator.SetFloat("HorizontalVelocity", Mathf.Abs(rb.velocity.x));
        _animator.SetFloat("VerticalVelocity", Mathf.Abs(rb.velocity.y));
        _animator.SetBool("isGrounded", IsGrounded());
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
