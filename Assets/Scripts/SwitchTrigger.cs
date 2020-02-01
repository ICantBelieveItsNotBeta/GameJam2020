using UnityEngine;

public class SwitchTrigger : TriggerBase
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<TopMovement>() != null && Input.GetButtonDown("Action"))
        {
            foreach (var reactive in reactiveObjects)
            {
                reactive.ToggleState();
            }
        }
    }
}