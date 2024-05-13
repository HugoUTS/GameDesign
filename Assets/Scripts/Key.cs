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
                    // Disable the collider to prevent further triggering
                    GetComponent<Collider2D>().enabled = false;
                    // Hide the key visually
                    GetComponent<SpriteRenderer>().enabled = false;
                    // Delay the destruction until the sound has finished
                    Destroy(gameObject, pickupAudioSource.clip.length);
                }
                else
                {
                    // Immediately hide or disable the key if no audio source is found
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
