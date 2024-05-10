using UnityEngine;
using UnityEngine.SceneManagement; // Required to load scenes

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

            if (playerInventory != null && playerInventory.hasKey) // Check if the player has the key
            {
                LoadNextScene();
            }
            else
            {
                Debug.Log("Player does not have the key!"); // Optional: Provide feedback if the player lacks the key
            }
        }
    }

    void LoadNextScene()
    {
        string currentScene = SceneManager.GetActiveScene().name; // Get the current scene name
        string nextScene = ""; // Placeholder for the next scene name

        // Determine the next scene based on the current scene
        switch (currentScene)
        {
            case "Tutorial":
                nextScene = "HugoScene";
                break;
            case "HugoScene":
                nextScene = "KDScene";
                break;
            case "KDScene":
                nextScene = "YanjieScene";
                break;
            case "YanjieScene":
                nextScene = "HugoScene"; // Loop back to the first scene, or you can stop cycling scenes
                break;
            default:
                Debug.Log("Scene name not recognized.");
                return; // Exit the method if the scene name doesn't match
        }

        SceneManager.LoadScene(nextScene); // Load the determined next scene
    }
}
