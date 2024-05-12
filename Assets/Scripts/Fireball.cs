using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Check if fireball hits an object tagged as "Enemy"
        {
            // Assuming the enemy has an Enemy script attached
            Enemy enemyScript = other.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.Die();
            }

            // Destroy the fireball on collision with an enemy
            Destroy(gameObject);
        }
        if (other.CompareTag("Ground")) // Check if fireball hits the ground
        {
            Destroy(gameObject); // Destroys the fireball on collision with a tile
        }
    }
}
