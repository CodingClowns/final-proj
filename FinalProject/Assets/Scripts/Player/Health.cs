using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private float maxInvincibilityTime;
    private int currentHealth;
    private float invincibilityTime;

    public int CurrentHealth
    {
        get => currentHealth;
    }

    public bool CanDamage()
    {
        return invincibilityTime <= 0;
    }

    private void FixedUpdate()
    {
        if (invincibilityTime > 0)
        {
            invincibilityTime -= Time.deltaTime;
        }
    }
}
