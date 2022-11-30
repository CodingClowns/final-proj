using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Sprite Idel;
    [SerializeField] private Sprite Crouch;
    [SerializeField] private BoxCollider2D collider2D;
    [SerializeField] private SpriteRenderer sp;


    private bool PlayerIsJumpable = false;
    private float horizontalMovement;
    private float oringinalspeed;
    private Vector2 IdelSize;
    private Vector2 CrouchSize;
    // Start is called before the first frame update
    private void Start()
    {
        /*collider2D.size = IdelSize;
        sp.sprite = Idel;

        IdelSize = collider2D.size;*/
        oringinalspeed = speed;
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
    }
    //Player Movement controller
    public void Movement()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space)&&PlayerIsJumpable)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            PlayerIsJumpable = false;
        }
        //walk
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;
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
        //run
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = oringinalspeed;
        }
    }
    //fixed update
    public void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
    }
    //groundCheck
    public void IsOnGround()
    {
        PlayerIsJumpable = true;
        if (PlayerIsJumpable)
        {
            Debug.Log("ok");
        }
    }
}
