using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Reference to the UI Slider
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script

    void Start()
    {
        // Initialize the health bar with the player's current health
        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.currentHealth;
    }

    public void UpdateHealth(int newHealth)
    {
        // Update the health bar with the new health value
        healthSlider.value = newHealth;
    }
}

