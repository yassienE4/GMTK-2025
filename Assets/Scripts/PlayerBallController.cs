using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveForce = 5f;
    public float maxSpeed = 10f;
    public float airControlMultiplier = 0.2f;
    
    private Rigidbody2D rb;
    
    public Transform groundCheck;
    public float groundCheckRadius = 1f;
    public LayerMask groundLayer;

    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Vector2 groundCheckPos = (Vector2)transform.position + Vector2.down * 0.6f; // adjust the offset
        isGrounded = Physics2D.OverlapCircle(groundCheckPos, groundCheckRadius, groundLayer);
        //Debug.Log(isGrounded);
        // Move left/right - using AddForce to conserve momentum
        float moveInput = Input.GetAxis("Horizontal");
        
        // Apply different force based on whether we're grounded or in air
        float currentMoveForce = isGrounded ? moveForce : moveForce * airControlMultiplier;
        
        // Only apply force if we haven't reached max speed in that direction
        if (Mathf.Abs(rb.linearVelocity.x) < maxSpeed)
        {
            rb.AddForce(moveInput * currentMoveForce * Vector2.right);
        }

        // Jump - only when grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    
    
}
