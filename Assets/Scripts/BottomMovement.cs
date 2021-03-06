﻿using System.Collections;
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
    private float direction = 1f;

    Light2D selectionLlight;
    private Animator _animator;

    void Start()
    {
        selectionLlight = GetComponentInChildren<Light2D>();

        rb = GetComponent<Rigidbody2D>();
        accel = accel * rb.mass;
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        _animator = GetComponentInChildren<Animator>();
        ChangeLight(activeHalf);
    }

    // Update is called once per frame
    void Update()
    {
        var jump = Input.GetButtonDown("Jump");
        if (activeHalf && jump && IsGrounded())
        {
            rb.velocity += Vector2.up * jumpforce;
        }
        if (rb.velocity.x != 0f)
        {
            direction = (Mathf.Abs(rb.velocity.x) / rb.velocity.x);
        }

        _animator.transform.localScale = new Vector3(direction * Mathf.Abs(_animator.transform.localScale.x), _animator.transform.localScale.y, 1);
        GetComponent<SpriteRenderer>().flipX = direction == -1;
        _animator.SetFloat("HorizontalVelocity", Mathf.Abs(rb.velocity.x));
        _animator.SetFloat("VerticalVelocity", Mathf.Abs(rb.velocity.y));

        if (!IsGrounded()) {
            Invoke("animateInair", 0.5f);
        }
        else {
        _animator.SetBool("isGrounded", true);
        }
        var light = GetComponentInChildren<Light2D>().transform;
        if (direction != 0f)
        {
            light.localPosition = new Vector3(-direction * Mathf.Abs(light.localPosition.x), light.localPosition.y);
        }
    }
    bool IsGrounded()    
    {
        return feet.colliding;
    }

    void animateInair() {
        _animator.SetBool("isGrounded", IsGrounded());
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
