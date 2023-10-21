using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_sc : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float doubleJumpForce = 7f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRadius;
    [SerializeField] LayerMask groundLayer;

    Rigidbody2D rb;
    bool isGrounded;
    bool canDoubleJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    { 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Movimiento horizontal
        float currentSpeed = isRunning ? runSpeed : moveSpeed;
        rb.velocity = new Vector2(horizontalInput * currentSpeed, rb.velocity.y);

        // Saltar
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        else if (canDoubleJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                canDoubleJump = false;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
