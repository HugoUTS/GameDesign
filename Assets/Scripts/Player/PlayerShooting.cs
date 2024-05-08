using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject fireballPrefab; // Assign the fireball prefab in the Inspector
    public float fireballSpeed = 10f; // Speed at which the fireball travels

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect left mouse button click
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        if (fireballPrefab != null)
        {
            // Instantiate the fireball at the player's position
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

            // Calculate the direction from the player to the mouse cursor
            Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            direction.z = 0; // Ensure the direction vector is strictly 2D

            // Normalize the direction to have a magnitude of 1
            direction = direction.normalized;

            // Set the fireball's velocity
            Rigidbody2D rbFireball = fireball.GetComponent<Rigidbody2D>();
            if (rbFireball != null)
            {
                rbFireball.velocity = direction * fireballSpeed; // Use the normalized direction multiplied by the desired speed
            }
        }
    }
}

