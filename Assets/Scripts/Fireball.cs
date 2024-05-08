using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Check if fireball hits an object tagged as "Enemy"
        {
            Destroy(other.gameObject);// Add damage to the enemy here if needed
            Destroy(gameObject); // Destroy the fireball on collision with an enemy
        }
        if (other.CompareTag("Ground"))  // Replace "Tile" with your tag
        {
            Destroy(gameObject);  // Destroys the fireball on collision with a tile
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);  // Destroys the fireball on any collision
        }
    }
    
    
    
}
