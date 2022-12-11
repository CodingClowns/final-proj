using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EnemyBoolEvent(bool right);
/// <summary>
/// Makes an object a walking enemy with edge detection.
/// Edge detection only works if there is a trigger on either side of the enemy to detect
/// when an edge is no longer there for the enemy to stand on.
/// </summary>
public class WalkingEnemy : MonoBehaviour
{
    /// <summary>
    /// This event is called when the enemy changes direction. 
    /// The new direction is passed in as a parameter.
    /// This is used for animation purposes.
    /// </summary>
    public event EnemyBoolEvent OnChangeDirection;

    [Tooltip("Should this enemy turn around at edges?")]
    [SerializeField] private bool edgeDetection = true;
    [Tooltip("How fast the enemy walks.")]
    [SerializeField] private float walkSpeed = 3;

    [Header("References")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Health health;

    private Vector3 previousPos;
    private bool right = true;

    private void Start()
    {
        health.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, previousPos) <= Mathf.Epsilon)
        {
            ChangeDirection();
            //print("Changing direction! Mwahahahaha");
        }

        previousPos = transform.position;
        rigidBody.velocity = new Vector2(right ? walkSpeed : -walkSpeed, rigidBody.velocity.y);
    }

    /// <summary>
    /// Toggles movement direction and calls an event.
    /// </summary>
    private void ChangeDirection()
    {
        right = !right;
        OnChangeDirection(right);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (edgeDetection && !collision.CompareTag("Player"))
        {
            ChangeDirection();
        }
    }
}
