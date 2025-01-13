using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Camera mainCamera;
    public float baseMoveSpeed = 5f; // Base speed of player movement
    public float acceleration = 2f; // How quickly the speed increases
    public float maxSpeedMultiplier = 3f; // Maximum multiplier for the speed
    public float deceleration = 5f; // How quickly the speed decreases when input is released

    private float currentSpeedMultiplier = 1f; // Current speed multiplier
    private bool isGrounded = true; // Sta

    private void Start()
    {
        // Find the main camera in the scene
        mainCamera = Camera.main;

        // Hide and lock the cursor
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Make the cursor invisible
    }

    private void Update()
    {
        // Rotate the player towards the camera every frame
        RotatePlayerTowardsCamera();

        if (isGrounded)
        {
            // Move the player every frame
            MovePlayer();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void RotatePlayerTowardsCamera()
    {
        if (mainCamera != null)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            cameraForward.y = 0f; // Ignore the y-axis rotation

            if (cameraForward != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(cameraForward);
                transform.rotation = newRotation;
            }
        }
    }

    private void MovePlayer()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float verticalInput = Input.GetAxis("Vertical");     // W/S or Up/Down Arrow

        // Check if there is any input
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            // Increase the speed multiplier
            currentSpeedMultiplier += acceleration * Time.deltaTime;
            currentSpeedMultiplier = Mathf.Min(currentSpeedMultiplier, maxSpeedMultiplier); // Clamp to max multiplier
        }
        else
        {
            // Decrease the speed multiplier
            currentSpeedMultiplier -= deceleration * Time.deltaTime;
            currentSpeedMultiplier = Mathf.Max(currentSpeedMultiplier, 1f); // Clamp to minimum base speed
        }

        // Calculate movement direction relative to the player's current rotation
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // Apply movement
        transform.position += moveDirection.normalized * baseMoveSpeed * currentSpeedMultiplier * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    IEnumerator DestroyBola()
    {
        if (isGrounded)
        {
            yield break;
        }
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}

