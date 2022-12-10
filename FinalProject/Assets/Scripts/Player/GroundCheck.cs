using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects ground collision and tells the player when they can jump.
/// </summary>
public class GroundCheck : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private GameObject player;
    
    // GroundCheck
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) //The player can jump on anything except its own collider.
        {
            //Debug.Log("Player jumpable");
            movement.IsOnGround();
        }
    }
}
