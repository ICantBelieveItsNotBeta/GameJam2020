using System;
using UnityEngine;

public class LiftAction : ReactiveObject
{
    public float speed = 0.01f;
    public Vector3 targetPosition;

    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
        targetPosition += _startPosition;
    }

    public override void Activate()
    {
        _opening = true;
    }

    public override void Deactivate()
    {
        _opening = false;
    }

    private void Update()
    {
        if (_opening && transform.localPosition != targetPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, speed);
        }
        else if (!_opening && transform.localPosition != _startPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _startPosition, speed);
        }
    }
}