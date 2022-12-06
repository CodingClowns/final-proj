using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool canJump = true;
    float horizontalMovement;
    void Start()
    {
        rb.freezeRotation = true;
    }

    void Update()
    {
        animator.SetBool("IsRunning", false);
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("Jump", true);
            canJump = false;
        }
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;
        if(horizontalMovement > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("IsRunning", true);
        }
        else if(horizontalMovement < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("IsRunning", true);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (collision.gameObject.tag == "Platform")
        {
            animator.SetBool("Jump", false);
            canJump = true;

        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
    }
}
