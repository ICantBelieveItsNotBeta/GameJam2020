using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public bool colliding;
    public bool top;
    public bool finished;
    void OnTriggerEnter2D(Collider2D collision)
    {
        colliding = true;
        if (top && (collision.gameObject.GetComponent<BottomMovement>() != null))
        {
            finished = true;
            print("finished!");
        }


    }
    void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;

    }

}
