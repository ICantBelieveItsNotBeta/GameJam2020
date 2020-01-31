using UnityEngine;

public class PressureTrigger : MonoBehaviour
{
    public ReactiveObject reactiveObject;
    public bool playerOnly = false;

    private BoxCollider2D _trigger;
    private int _triggerCount;

    private void Awake()
    {
        _trigger = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!playerOnly)
            _triggerCount++;
        else
        {
            if (collision.collider.CompareTag("Player"))
            {
                _triggerCount++;
            }
        }

        if (_triggerCount > 0)
        {
            reactiveObject.Activate();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!playerOnly)
            _triggerCount--;
        else
        {
            if (collision.collider.CompareTag("Player"))
            {
                _triggerCount--;
            }
        }

        if (_triggerCount <= 0)
        {
            reactiveObject.Deactivate();
        }
    }
}