using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private new Rigidbody2D rigidbody;

    private void AnimationUpdate(float deltaTime)
    {
        animator.SetBool("isRunning", Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon);
    }

    private void Update()
    {
        AnimationUpdate(Time.deltaTime);
    }
}
