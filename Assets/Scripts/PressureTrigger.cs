using UnityEngine;

public class PressureTrigger : MonoBehaviour
{
    public ReactiveObject reactiveObject;
    public bool playerOnly = false;

    private int _triggerCount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!playerOnly)
            _triggerCount++;
        else
        {
            if (other.CompareTag("Player"))
            {
                _triggerCount++;
            }
        }

        if (_triggerCount > 0)
        {
            reactiveObject.Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!playerOnly)
            _triggerCount--;
        else
        {
            if (other.CompareTag("Player"))
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