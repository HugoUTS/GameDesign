using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource deathAudioSource; // Assign this in the Inspector

    public void Die()
    {
        // Play death sound
        deathAudioSource.Play();

        // Destroy the enemy after the sound has played
        Destroy(gameObject, deathAudioSource.clip.length);
    }
}
