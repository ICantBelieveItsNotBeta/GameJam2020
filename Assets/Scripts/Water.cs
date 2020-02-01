using UnityEngine;

public class Water : MonoBehaviour
{
    private WorldManager _worldManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _worldManager.Kill();
        }
    }
}