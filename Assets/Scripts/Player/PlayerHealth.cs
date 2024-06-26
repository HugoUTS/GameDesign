using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health
    public int currentHealth;   // Current health
    public HealthBar healthBar; // Reference to the HealthBar script
    public AudioSource damageAudioSource; // Assign an AudioSource for damage sound in the Inspector

    void Start()
    {
        // Initialize the player's health and update the health bar
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.UpdateHealth(maxHealth);
        }
    }

    // Method to apply damage to the player
    public void TakeDamage(int damage)
    {
        // Reduce the player's health by the specified damage amount
        currentHealth -= damage;

        // Play the damage sound
        if (damageAudioSource != null)
        {
            damageAudioSource.Play();
        }

        // Update the health bar
        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth);
        }

        // Check if the player's health has reached zero
        if (currentHealth <= 0)
        {
            Die(); // Handle the player's death
        }
    }

    // Method to handle the player's death
    void Die()
    {
        Debug.Log("Player died!"); // Simple log message for debugging
        // Additional logic for game over or player death
        SceneManager.LoadScene("GameOverScene");// For example, reload the scene, display a game over screen, or disable the player
    }
}
