using UnityEngine;

public class Key : MonoBehaviour
{
    public AudioSource pickupAudioSource; // Assign an AudioSource for pickup sound in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player triggering
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

            if (playerInventory != null) // Ensure the player has an inventory
            {
                playerInventory.CollectKey(); // Indicate the player has collected the key

                // Play the pickup sound
                if (pickupAudioSource != null)
                {
                    pickupAudioSource.Play();
                }

                // Hide or disable the key upon pickup
                gameObject.SetActive(false); 
            }
        }
    }
}
