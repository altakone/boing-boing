using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Player object to follow
    public float rotationSpeed = 2.0f; //  hor Mouse rotation speed
    public float verticalRotationSpeed = 1.0f; // Vertical rotation speed

    private Vector3 offset;   // Distance difference between camera and player

    void Start()
    {
        // Calculate and save the distance when the game starts
        if (player != null)
        {
            offset = transform.position - player.transform.position;
        }
        else
        {
            Debug.LogWarning("CameraController: Player object not assigned!");
        }
    }

    // LateUpdate runs after all Update functions are finished.
    // Ideal for camera following because player movement is completed.
    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate rotation with mouse input
            float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
            float verticalInput = Input.GetAxis("Mouse Y") * verticalRotationSpeed;
            
            // Horizontal rotation (around Y axis)
            Quaternion turnAngle = Quaternion.AngleAxis(horizontalInput, Vector3.up);
            offset = turnAngle * offset;

            // Vertical rotation (around camera's right axis)
            // When mouse is pushed up, camera goes down and looks up (Orbit style)
            Quaternion pitchAngle = Quaternion.AngleAxis(-verticalInput, transform.right);
            Vector3 newOffset = pitchAngle * offset;


            // Prevent camera from flipping over or going underground (Clamp)
            // Check angle between offset vector and Up vector
            float angle = Vector3.Angle(newOffset, Vector3.up);

            // 0 degrees is top, 90 degrees is ground level. 
            // Prevent camera from going too high (Gimbal lock risk) or underground.
            if (angle > 5f && angle < 100f)
            {
                offset = newOffset;
            }

            // Update camera position
            transform.position = player.transform.position + offset;

            // Ensure camera always looks at the player
            transform.LookAt(player.transform.position);
        }
    }
}
