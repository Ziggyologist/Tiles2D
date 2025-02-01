using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float runSpeed = 6f;
    [SerializeField] float jumpSpeed = 20f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float gravityScaleAtStart = 6f;
    
    Rigidbody2D rb;
    Animator animator;
    CapsuleCollider2D bodyCollider2d;
    BoxCollider2D feetCollider2d;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScaleAtStart;
        animator = GetComponent<Animator>();
        bodyCollider2d = GetComponent<CapsuleCollider2D>();
        feetCollider2d = GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value) 
    {
        int ground = LayerMask.GetMask("Ground");
        if (value.isPressed && feetCollider2d.IsTouchingLayers(ground)) 
        {
            rb.linearVelocity += new Vector2(0f, jumpSpeed);
        }
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rb.linearVelocity.y);
        rb.linearVelocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void ClimbLadder()
    {
        int ladderLayer = LayerMask.GetMask("Ladder");
        if (!feetCollider2d.IsTouchingLayers(ladderLayer))
        {
            rb.gravityScale = gravityScaleAtStart;
            return; 
        }
        rb.gravityScale = 0f;
        Vector2 climbVelocity = new Vector2(rb.linearVelocity.x, moveInput.y * climbSpeed);
        rb.linearVelocity = climbVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.y) > Mathf.Epsilon;
        animator.SetBool("isClimbing", playerHasHorizontalSpeed);
       
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocity.x), 1f);
        }
    }

}
