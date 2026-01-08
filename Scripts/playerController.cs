
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float BASE_SPEED;
    public float BASE_JUMP_FORCE;
    public float moveSpeed;
    public float jumpForce;
    public float mass = 3f;
    
    [Header("Drag Settings")]
    public float groundDrag = 0.1f;
    public float airDrag = 0.1f;
    public float mudDrag = 5f;
    public float iceDrag = 0.01f;
    
    public float airControl = 0.8f; // Air control multiplier

    [HideInInspector]
    public GameObject currentGroundObject;

    private Rigidbody rb;
    private bool isGrounded;
    private float currentGroundDrag;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
        currentGroundDrag = groundDrag;
        moveSpeed = BASE_SPEED;
        jumpForce = BASE_JUMP_FORCE;

    }

    void Update()
    {
        // Jump input (Space key by default)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // ForceMode.Impulse applies an instant force, ideal for jumping
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement vector based on camera direction
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        // Zero out the Y axis so looking up/down doesn't affect movement
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 movement = (camForward * moveVertical + camRight * moveHorizontal).normalized;

        if (isGrounded)
        {
            rb.drag = currentGroundDrag;
            // Normal movement when grounded
            rb.AddForce(movement * moveSpeed);
        }
        else
        {
            rb.drag = airDrag;
            // Restricted control when airborne (Air Control)
            rb.AddForce(movement * moveSpeed * airControl);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Collect coin
        if(collision.gameObject.CompareTag("coin")){
            Destroy(collision.gameObject);
            
        }
        else if(collision.gameObject.CompareTag("enemy"))
        {
            // Calculate knockback direction (away from enemy)
            Vector3 knockbackDir = (transform.position - collision.transform.position).normalized;
            
            // Add upward component for a better "bump" feel
            knockbackDir.y = 0.5f; 
            knockbackDir.Normalize();

            // Apply force to player (me)
            rb.AddForce(knockbackDir * 35f + Vector3.up * 10f, ForceMode.Impulse);
        }
    }

    // Simple ground check
    void OnCollisionStay(Collision collision)
    {
        // Check if grounded by looking at the surface normal of contact points
        foreach (ContactPoint contact in collision.contacts)
        {
            // If normal points up (surface is flat), it is grounded
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.7f)
            {
                // reset grounded state and adjust properties
                isGrounded = true;
                currentGroundObject = collision.gameObject;



                // Reaction based on ground type
                if (collision.gameObject.CompareTag("mud"))
                {
                    currentGroundDrag = mudDrag;
                    moveSpeed = BASE_SPEED * 0.8f;
                    jumpForce = BASE_JUMP_FORCE * 1f;

                }
                else if (collision.gameObject.CompareTag("ice"))
                {
                    currentGroundDrag = iceDrag;
                    jumpForce = BASE_JUMP_FORCE * 1f;
                    moveSpeed = BASE_SPEED * 1.5f;

                    
                }
                else if(collision.gameObject.CompareTag("trampoline"))
                {
                    currentGroundDrag = groundDrag;
                    jumpForce = BASE_JUMP_FORCE * 1.5f;

                }
                else if(collision.gameObject.CompareTag("finish"))
                {
                    // You win!
                    // stop game
                    Debug.Log("You Win!");
                    Time.timeScale = 0f;
                    

                }
                else
                {
                    moveSpeed = BASE_SPEED;
                    jumpForce = BASE_JUMP_FORCE;
                    currentGroundDrag = groundDrag;
                }
                

                return;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        if (collision.gameObject == currentGroundObject)
        {
            currentGroundObject = null;
        }
    }
}
