using UnityEngine;

public class PressureTrigger : TriggerBase
{

    private int _triggerCount;
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool cond = other.GetComponent<Block>() || other.GetComponent<BottomMovement>();
        if (cond)
        {
            _triggerCount++;
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
        bool cond = other.GetComponent<Block>() || other.GetComponent<BottomMovement>();
        if (cond)
        {
            _triggerCount--;
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