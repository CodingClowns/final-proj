using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("How fast the player moves.")]
    [SerializeField] private float speed;
    [Tooltip("How much force the player jumps with.")]
    [SerializeField] private float jumpForce;

    [Header("References")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite crouchingSprite;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool crouching = false;
    private bool canJump = false;
    private bool jumping = false;
    private float horizontalMovement;
    private Vector2 hitboxIdle;
    private Vector2 hitboxCrouching;

    //Player Movement controller

    /// <summary>
    /// Takes the player's input for movement.
    /// </summary>
    public void GetInputs()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            jumping = true;
            canJump = false;
        }

        //Horizontal Input
        horizontalMovement = Input.GetAxisRaw("Horizontal") *
            //Crouching
            (crouching ? speed * 0.5f :
            //Running
            Input.GetKey(KeyCode.LeftShift) ? 2 * speed : 
            //Walking
            speed);

        //crouch
        /*        if (Input.GetKeyDown(KeyCode.C))
                {
                    sp.sprite = Crouch;
                    collider2D.size = CrouchSize;
                }
                if (Input.GetKeyUp(KeyCode.C))
                {
                    sp.sprite = Idel;
                    collider2D.size = IdelSize;
                }*/
    }
    
    /// <summary>
    /// Executes movement.
    /// </summary>
    private void Movement()
    {
        //Horizontal movement
        rigidBody.velocity = new Vector2(horizontalMovement, rigidBody.velocity.y);

        //Jumping
        if (jumping)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
            jumping = false;
        }
    }

    /// <summary>
    /// Sets the player's CanJump variable to true.
    /// </summary>
    public void IsOnGround()
    {
        canJump = true;
        //if (canJump)
        //{
        //    Debug.Log("ok");
        //}
    }

    private void Start()
    {
        /*collider2D.size = IdelSize;
        sp.sprite = Idel;

        IdelSize = collider2D.size;*/
    }

    private void Update()
    {
        GetInputs();
    }

    public void FixedUpdate()
    {
        Movement();
    }
}
