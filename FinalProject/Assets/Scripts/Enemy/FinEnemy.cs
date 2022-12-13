using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used solely for animating enemies.
/// </summary>
public class FinEnemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private WalkingEnemy edgeDetection;
    [SerializeField] private Animator animator;

    private void Start()
    {
        edgeDetection.OnChangeDirection += ChangeDirection;
    }

    /// <summary>
    /// Causes enemies to flip their sprites when changing direction.
    /// </summary>
    /// <param name="right"></param>
    private void ChangeDirection(bool right)
    {
        animator.SetBool("Facing", right);
    }
}
