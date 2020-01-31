using UnityEngine;

public class DoorAction : ReactiveObject
{
    public float speed = 0.5f;
    public bool vertical = true;
    
    private bool _opening;
    private Vector3 _vector;
    private float _initialSize;

    void Awake()
    {
        if (vertical)
        {
            _initialSize = transform.parent.localScale.y;
            _vector = new Vector3(0, speed, 0);
        }
        else
        {
            _initialSize = transform.parent.localScale.x;
            _vector = new Vector3(speed, 0, 0);
        }
    }

    public override void Activate()
    {
        _opening = true;
    }

    public override void Deactivate()
    {
        _opening = false;
    }

    public void Update()
    {
        if (vertical)
        {
            if (_opening && transform.parent.localScale.y > 0)
                transform.parent.localScale -= _vector;
            else if (!_opening && transform.localScale.y < _initialSize)
                transform.parent.localScale += _vector;
        }
        else
        {
            if (_opening && transform.parent.localScale.x > 0)
                transform.parent.localScale -= _vector;
            else if (!_opening && transform.parent.localScale.x < _initialSize)
                transform.parent.localScale += _vector;
        }
    }
}