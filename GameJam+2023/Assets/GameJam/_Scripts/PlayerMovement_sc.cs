using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_sc : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    
    [Header("Speed")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float runSpeed = 10f;

    [Header("Jump")]
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float doubleJumpForce = 7f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRadius;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] bool isGrounded;
    bool canDoubleJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        float currentSpeed = horizontalInput!=0 ? isRunning ? runSpeed : moveSpeed:0;
        rb.velocity = new Vector2(horizontalInput * currentSpeed, rb.velocity.y);

        if (horizontalInput > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (isGrounded)
        {
            canDoubleJump = true;
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
        animator.SetFloat("currentSpeed", currentSpeed);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("canDoubleJump", canDoubleJump);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
