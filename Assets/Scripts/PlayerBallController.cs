using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveForce = 70f;
    public float maxSpeed = 20f;
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
    private float moveInput;
    private bool jumpRequested;

    void Update()
    {
        // Get input in Update (input works best here)
        moveInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }

        // Ground check
        Vector2 groundCheckPos = (Vector2)transform.position + Vector2.down * 0.6f;
        isGrounded = Physics2D.OverlapCircle(groundCheckPos, groundCheckRadius, groundLayer);
    }

    void FixedUpdate()
    {
        // Apply different force based on whether grounded or in air
        float currentMoveForce = isGrounded ? moveForce : moveForce * airControlMultiplier;

        if (Mathf.Abs(rb.linearVelocity.x) < maxSpeed)
        {
            rb.AddForce(moveInput * currentMoveForce * Vector2.right);
        }

        if (jumpRequested)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpRequested = false;
        }
    }

    
    
}
