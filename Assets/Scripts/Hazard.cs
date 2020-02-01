using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    private Vector3 _startPosition;
    // public float speed = 0.01f;
    public GameObject wall;
    public float speed;
    public bool clockwise;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WorldManager.worldManager.Kill();
        }
    }

    private void Update()
    {
        transform.RotateAround(wall.transform.position, (clockwise == true) ? Vector3.forward : Vector3.back, (360 - (360/speed)) * Time.deltaTime);
    }
}
