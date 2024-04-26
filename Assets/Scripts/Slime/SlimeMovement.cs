using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public float speed = 2.0f; // Speed of the enemy
    public bool moveRight = true; // Initial movement direction

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move the enemy left or right based on the current direction
        if (moveRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y); // Move right
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y); // Move left
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Change direction when hitting an obstacle or edge
        if (other.CompareTag("Edge"))
        {
            moveRight = !moveRight; // Reverse the direction
            Flip(); // Flip the enemy's sprite
        }
    }

    void Flip()
    {
        // Flip the enemy's sprite when changing direction
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

