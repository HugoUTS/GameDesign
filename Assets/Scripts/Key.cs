using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player triggering
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

            if (playerInventory != null) // Ensure the player has an inventory
            {
                playerInventory.CollectKey(); // Indicate the player has collected the key
                gameObject.SetActive(false);  // Hide or disable the key upon pickup
            }
        }
    }
}

