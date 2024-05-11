using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpForce = 2.0f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool isFacingRight = true; // Assume the character is facing right by default
    public float fallBoundary = -25f;

    public AudioSource walkAudioSource; // Assign this in the inspector
    public AudioSource jumpAudioSource; // Assign this in the inspector
    public AudioSource landAudioSource; // Assign this in the inspector for landing sound

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        // For animation, we need to check if there is horizontal movement
        if (moveHorizontal != 0 && isGrounded)
        {
            animator.SetBool("isWalking", true);
            if (!walkAudioSource.isPlaying)
            {
                walkAudioSource.Play();
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            walkAudioSource.Stop();
        }

        // Check if the character needs to flip
        if ((moveHorizontal > 0 && !isFacingRight) || (moveHorizontal < 0 && isFacingRight))
        {
            Flip();
        }

        // Update the character's position
        transform.position += new Vector3(moveHorizontal, 0.0f, 0.0f) * speed * Time.deltaTime;

        // Check for jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            jumpAudioSource.Play();
        }

        if (transform.position.y <= fallBoundary)
        {
            Die();
        }
    }

    void Flip()
    {
        // Toggle the direction
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Flip the X axis
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            if (!isGrounded)
            {
                landAudioSource.Play(); // Play landing sound when hitting the ground
            }
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Die()
    {
        Debug.Log("Player has died");  // Optional: Output a debug message
        SceneManager.LoadScene("GameOverScene");  // Replace "GameOverScene" with your actual game over scene name
    }
}
