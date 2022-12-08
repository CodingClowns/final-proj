using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerMovement playerMovement;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerMovement.IsOnGround();
            Debug.Log("Onground!");
        }
    }
}
