using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The character that the camera needs to follow
    public float smoothing = 5f; // Smoothness of the camera movement
    public Vector3 offset; // Offset of the camera from the character

    void Start()
    {
        // Calculate the initial offset
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Calculate the new position of the camera
        Vector3 targetCamPos = target.position + offset;
        
        // Smoothly move the camera to the new position
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
