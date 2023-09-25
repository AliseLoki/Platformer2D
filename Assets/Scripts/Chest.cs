using UnityEngine;

public class Chest : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
            Debug.Log("YOU WIN");
        }
    }
}
