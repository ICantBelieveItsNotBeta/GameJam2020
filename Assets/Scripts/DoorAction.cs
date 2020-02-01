using UnityEngine;

public class DoorAction : ReactiveObject
{
    public float speed = 0.05f;
    
    private Vector3 _vector;
    private float _initialSize;

    void Awake()
    {
        _initialSize = transform.parent.localScale.y;
        _vector = new Vector3(0, speed, 0);
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
        if (_opening && transform.parent.localScale.y > 0)
        {
            transform.parent.localScale -= _vector;
            if (transform.parent.localScale.y < 0)
            {
                transform.parent.localScale = new Vector3(
                    transform.parent.localScale.x,
                    0,
                    transform.parent.localScale.z);
            }
        }
        else if (!_opening && transform.parent.localScale.y < _initialSize)
            transform.parent.localScale += _vector;
    }
}