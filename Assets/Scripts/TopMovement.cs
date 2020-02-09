using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TopMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float distToGround = 0;
    public float runspeed;
    public float accel;
    public bool activeHalf;
    float grav;
    public BottomMovement bottom;
    public Feet feet;
    Rigidbody2D rb;

    private Animator _animator;



    Light2D selectionLlight;


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
        ChangeLight(activeHalf);
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
        
        var direction = Input.GetAxisRaw("Horizontal");
        if (direction != 0) {
        _animator.transform.localScale = new Vector3(direction * Mathf.Abs(_animator.transform.localScale.x),
            _animator.transform.localScale.y, 1);
        GetComponent<SpriteRenderer>().flipX = direction == -1;
        }
        _animator.SetFloat("HorizontalVelocity", Mathf.Abs(rb.velocity.x));

        if (!IsGrounded()) {
            Invoke("animateInair", 0.5f);
        }
        else {
        }
        var light = GetComponentInChildren<Light2D>().transform;
        if (direction == -1)
        {
            light.localPosition = new Vector3(-0.26f, light.localPosition.y);
        }
        else if (direction == 1)
        {
            light.localPosition = new Vector3(-0.55f, light.localPosition.y);
        }
    }
    void animateInair() {
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
