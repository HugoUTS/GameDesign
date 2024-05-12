using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed = 10f;
    public AudioSource shootingAudioSource;
    private bool canShoot = false; // Player starts without the ability to shoot

    public void EnableShooting()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot) // Player can only shoot if they have collected the fire
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        if (fireballPrefab != null)
        {
            if (shootingAudioSource != null)
            {
                shootingAudioSource.Play();
            }

            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            direction.z = 0;
            direction = direction.normalized;

            Rigidbody2D rbFireball = fireball.GetComponent<Rigidbody2D>();
            if (rbFireball != null)
            {
                rbFireball.velocity = direction * fireballSpeed;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                fireball.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}


