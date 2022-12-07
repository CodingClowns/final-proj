using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    enum AnimationState
    {
        Idel,
        Walking,
        Running,
        Jumping,
        falling,
        Crouching,
        CrouchWalking,
        melee
    }
    [Tooltip("How fast the player moves.")]
    [SerializeField] private float speed;
    [Tooltip("How much force the player jumps with.")]
    [SerializeField] private float jumpForce;

    [Header("References")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator anim;
    /// <summary>
    /// Three colliders for player, Box and cirle for normal(idel,runing jumping falling and walking)
    /// CapsuleCollider for crouch and crouchwalking
    /// </summary>
    [SerializeField] private CapsuleCollider2D PlayerCrouchCollider;
    [SerializeField] private CircleCollider2D PlayerLowBodyPartCollider;
    [SerializeField] private BoxCollider2D PlayerTopBodyPartCollider;

    private bool crouching = false;
    private bool canJump = false;
    private bool jumping = false;
    private bool isrunning = false;
    private bool isMeleeing = false;

    private float horizontalMovement;

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
        //melee
        if (Input.GetKeyDown(KeyCode.V))
        {
            isMeleeing = true;
        }
        else if (Input.GetKeyUp(KeyCode.V))
        {
            isMeleeing = false;
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
                if (Input.GetKeyDown(KeyCode.C))
                {
                    PlayerCrouchCollider.enabled = true;
                    PlayerLowBodyPartCollider.enabled = false;
                    PlayerTopBodyPartCollider.enabled = false;
                    crouching = true;
                }
                if (Input.GetKeyUp(KeyCode.C))
                {
                    PlayerLowBodyPartCollider.enabled = true;
                    PlayerTopBodyPartCollider.enabled = true;
                    PlayerCrouchCollider.enabled = false;
                    crouching = false;
                }
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
            Debug.Log("jumping");
            jumping = false;
        }
    }

    /// <summary>
    /// Sets the player's CanJump variable to true.
    /// </summary>
    public void AnimaitonUpdates()
    {
        AnimationState state = AnimationState.Idel;
        if (horizontalMovement>0)
        {
            state = AnimationState.Walking;
            spriteRenderer.flipX = false;
        }
        else if (horizontalMovement <0)
        {
            state = AnimationState.Walking;
            spriteRenderer.flipX = true;
        }
        if (isrunning)
        {
            state = AnimationState.Running;
        }
        if (crouching)
        {
            state = AnimationState.Crouching;
        }
        if (crouching&&horizontalMovement>0)
        {
            state = AnimationState.CrouchWalking;
        }
        else if (crouching&&horizontalMovement<0)
        {
            state = AnimationState.CrouchWalking;
        }
        if (rigidBody.velocity.y > .1f) 
        {
            state = AnimationState.Jumping;
        }
        else if (rigidBody.velocity.y< -.1f)
        {
            state = AnimationState.falling;
        }
        if (isMeleeing)
        {
            anim.SetBool("melee", true);
        }
        else if (!isMeleeing)
        {
            anim.SetBool("melee", false);
        }
        anim.SetInteger("state", (int)state);
    }
    /// <summary>
    /// AnimationUpdates:
    /// by switching animation's state to change the player's animation
    /// Example:
    /// when walking, in Enum is 1, give the feedback of this number/position to animator,
    /// in the animator has a condition when is equal to one, then active walk animation.
    /// </summary>
    public void IsOnGround()
    {
        canJump = true;
        if (canJump)
        {
         Debug.Log("ok");
        }
    }

    private void Start()
    {
       
    }

    private void Update()
    {
        GetInputs();
        AnimaitonUpdates();
        checkifrunning();
    }

    public void checkifrunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isrunning = true;
            Debug.Log("is running");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isrunning = false;
            Debug.Log("is not running");
        }
    }
    public void FixedUpdate()
    {
        Movement();
    }
}
