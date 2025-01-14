using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb; // Rigidbody component for physics
    public bool isOnGround = false; // Check if the enemy has touched the ground
    private float offGroundTime = 0f; // Time spent off the ground
    public float respawnTime = 2f; // Maximum time allowed off the ground before respawning
    public float spawnHeight = 5f; // Initial spawn height
    public float boundary = 5f; // Boundary for respawning

    void Start()
    {
        // Get the Rigidbody component
        enemyRb = GetComponent<Rigidbody>();
        enemyRb.constraints = RigidbodyConstraints.FreezeRotation; // Prevent rotation

        // Spawn the enemy at an initial random location in the air
        Respawn();
    }

    void Update()
    {
        // Track time off the ground
        if (!isOnGround)
        {
            offGroundTime += Time.deltaTime;

            // Respawn if the enemy fails to touch the ground within the allowed time
            if (offGroundTime >= respawnTime)
            {
                Respawn();
            }
        }
    }

    private void Respawn()
    {
        // Randomize position within boundaries and spawn at a specific height
        transform.position = new Vector3(
            Random.Range(-boundary, boundary),
            spawnHeight, // Spawn from the air
            Random.Range(-boundary, boundary)
        );

        // Reset variables
        offGroundTime = 0f;
        isOnGround = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the enemy touches the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; // Enemy has landed
            offGroundTime = 0f; // Reset the timer
           
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // If the enemy leaves the ground, mark it as not on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
            Debug.Log("Enemy left the ground.");
        }
    }
}