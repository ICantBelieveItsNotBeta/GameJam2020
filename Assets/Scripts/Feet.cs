using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public bool colliding;
    public bool top;
    public float winAnimationTime;
    GameObject bottomhalf;
    GameObject tophalf;
    void Start()
    {
        bottomhalf = GameObject.Find("Bottom");
        tophalf = GameObject.Find("Top");
        WorldManager.worldManager.winAnimation.GetComponent<Animator>().SetBool("Won", false);

    }

    private void Update()
    {
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

            Invoke("Win", winAnimationTime);
            bottomhalf.SetActive(false);
            tophalf.SetActive(false);
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
