using UnityEngine;

public class PressureTrigger : MonoBehaviour
{
    public IReactiveObject reactiveObject;

    private Rigidbody2D _trigger;

    private void Awake()
    {
        _trigger = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.position.x > _trigger.position.x)
            reactiveObject.Activate();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        reactiveObject.Deactivate();
    }
}