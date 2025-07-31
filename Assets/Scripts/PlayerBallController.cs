using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveForce = 5f;
    public float maxSpeed = 10f;
    public float airControlMultiplier = 0.2f;
    
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move left/right - using AddForce to conserve momentum
        float moveInput = Input.GetAxis("Horizontal");
        
        // Apply different force based on whether we're grounded or in air
        float currentMoveForce = IsGrounded() ? moveForce : moveForce * airControlMultiplier;
        
        // Only apply force if we haven't reached max speed in that direction
        if (Mathf.Abs(rb.linearVelocity.x) < maxSpeed)
        {
            rb.AddForce(moveInput * currentMoveForce * Vector2.right);
        }

        // Jump - only when grounded
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        // Simple raycast to check for ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        return hit.collider != null;
    }
    
    
}
