using System;
using UnityEngine;

public class SwitchTrigger : TriggerBase
{
    private bool _inCollider;
    private TopMovement _topMovement;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<TopMovement>() != null)
        {
            _inCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<TopMovement>() != null)
        {
            _inCollider = false;
        }
    }

    private void Awake()
    {
        _topMovement = FindObjectOfType<TopMovement>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && _inCollider && _topMovement.activeHalf)
        {
            foreach (var reactive in reactiveObjects)
            {
                transform.GetChild(1).localScale = new Vector3(transform.GetChild(1).localScale.x, -transform.GetChild(1).localScale.y, transform.GetChild(1).localScale.z);
                reactive.ToggleState();
            }
        }
    }
}