using UnityEngine;
using UnityEngine.SceneManagement; // Required to load scenes

public class Door : MonoBehaviour
{
    public string nextSceneName = "NextLevel"; // Name of the next scene to load

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

            if (playerInventory != null && playerInventory.hasKey) // Check if the player has the key
            {
                SceneManager.LoadScene("HugoScene"); // Load the next scene
            }
            else
            {
                Debug.Log("Player does not have the key!"); // Optional: Provide feedback if the player lacks the key
            }
        }
    }
}