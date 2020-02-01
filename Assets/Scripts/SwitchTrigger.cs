using UnityEngine;

public class SwitchTrigger : TriggerBase
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player") && Input.GetButtonDown("Action"))
        {
            foreach (var reactive in reactiveObjects)
            {
                reactive.ToggleState();
            }
        }
    }
}