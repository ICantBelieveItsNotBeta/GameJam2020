using System.Collections;
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
    void OnTriggerStay2D(Collider2D collision)
    {
        colliding = true;
        if (top && (collision.gameObject.GetComponent<BottomMovement>() != null))
        {
            finished = true;
            Invoke("Win", winAnimationTime);
            bottomhalf.SetActive(false);
            tophalf.SetActive(false);
            // play animation
        }

    }
    void Win()
    {
        WorldManager.levelManager.WinLevel();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
    }

}
