using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody rb;
    private Vector3 moveInput;

    void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from WASD or Arrow Keys
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D
        float moveZ = Input.GetAxisRaw("Vertical");   // W/S

        moveInput = new Vector3(moveX, 0, moveZ).normalized;
    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody
        MovePlayer();
    }

   void MovePlayer()
    {
        // Calculate the movement vector
        Vector3 moveVelocity = moveInput * moveSpeed;
        
        // Use .velocity instead of .linearVelocity for Unity 2022.3
        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
    }
}