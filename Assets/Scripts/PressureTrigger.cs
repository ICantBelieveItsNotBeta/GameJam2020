using UnityEngine;

public class PressureTrigger : TriggerBase
{
    public bool playerOnly = false;

    private int _triggerCount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!playerOnly && other.GetComponent<TopMovement>() == null)
            _triggerCount++;
        else
        {
            if (other.GetComponent<TopMovement>() == null)
            {
                _triggerCount++;
            }
        }

        if (_triggerCount > 0)
        {
            foreach (var reactive in reactiveObjects)
            {
                reactive.Activate();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!playerOnly && other.GetComponent<TopMovement>() == null)
            _triggerCount--;
        else
        {
            if (other.GetComponent<TopMovement>() == null)
            {
                _triggerCount--;
            }
        }

        if (_triggerCount <= 0)
        {
            foreach (var reactive in reactiveObjects)
            {
                reactive.Deactivate();
            }
        }
    }
}