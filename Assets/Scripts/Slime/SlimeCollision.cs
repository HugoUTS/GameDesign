using UnityEngine;

public class SlimeCollision : MonoBehaviour
{
    public int damage = 10; // Damage dealt to the player
    public float pushbackForce = 5.0f; // Pushback force applied to the player

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();

            if (playerHealth != null)
            {
                // Apply damage to the player
                playerHealth.TakeDamage(damage);
            }

            if (playerRb != null)
            {
                // Calculate pushback direction (opposite to enemy direction)
                Vector2 pushbackDirection = (other.transform.position - transform.position).normalized;
                playerRb.AddForce(pushbackDirection * pushbackForce, ForceMode2D.Impulse); // Apply pushback force
            }
        }
    }
}


