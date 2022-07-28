using UnityEngine;

public class DestroyGameObject : MonoBehaviour//for destroying the obstacles after the player passes through. attached to a collider on camera below screen
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("pass"))
        {
            Destroy(other.gameObject);
        }
    }
}
