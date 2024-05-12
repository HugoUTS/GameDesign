using UnityEngine;

public class FireCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Make sure your player GameObject has the "Player" tag
        {
            PlayerShooting playerShooting = other.GetComponent<PlayerShooting>();
            if (playerShooting != null)
            {
                playerShooting.EnableShooting(); // Enable shooting for the player
            }
            Destroy(gameObject); // Destroy the collectible object after collection
        }
    }
}

