﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public bool colliding;
    public bool top;
    public bool finished;
    public float winAnimationTime;
    GameObject bottomhalf;
    GameObject tophalf;
    void Start()
    {
        bottomhalf = GameObject.Find("Bottom");
        tophalf = GameObject.Find("Top");

    }

    private void Update()
    {
        WorldManager.worldManager.winAnimation.GetComponent<Animator>().SetBool("Won", false);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        colliding = true;
        if (top && (collision.gameObject.GetComponent<BottomMovement>() != null))
        {
            GameObject anim = WorldManager.worldManager.winAnimation;

            anim.transform.position = collision.transform.position - Vector3.up * 1.2f;
            anim.GetComponent<Animator>().SetBool("Won", true);

            anim.GetComponent<AudioSource>().Play();

            //collision.gameObject.SetActive(false);
            //this.gameObject.SetActive(false);

            finished = true;
            Invoke("Win", winAnimationTime);
            bottomhalf.SetActive(false);
            tophalf.SetActive(false);
            // play animation
        }

    }
    void Win()
    {
        WorldManager.worldManager.winAnimation.GetComponent<Animator>().SetBool("Won", false);
        WorldManager.levelManager.WinLevel();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
    }

}
