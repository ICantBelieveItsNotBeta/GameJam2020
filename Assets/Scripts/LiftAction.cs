using System;
using UnityEngine;

public class LiftAction : ReactiveObject
{
    public float speed = 0.01f;
    public Vector3 targetPosition;
    
    private bool _activated;
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.localPosition;
    }

    public override void Activate()
    {
        _activated = true;
    }

    public override void Deactivate()
    {
        _activated = false;
    }

    private void Update()
    {
        if (_activated && transform.localPosition != targetPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, speed);
        }
        else if (!_activated && transform.localPosition != _startPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _startPosition, speed);
        }
    }
}