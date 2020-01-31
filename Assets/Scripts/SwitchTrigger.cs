using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public ReactiveObject reactiveObject;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player") && Input.GetButtonDown("Action"))
        {
            reactiveObject.ToggleState();
        }
    }
}