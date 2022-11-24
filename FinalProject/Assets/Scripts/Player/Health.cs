using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PlayerVoidEvent();
public delegate void PlayerBoolEvent(bool value);

public class Health : MonoBehaviour
{
    public event PlayerVoidEvent OnDeath;
    public event PlayerBoolEvent OnDamaged;

    [SerializeField] private int maxHealth;
    [SerializeField] private float maxInvincibilityTime;
    private int currentHealth;
    private float invincibilityTime;

    /// <summary>
    /// Current health of the player.
    /// </summary>
    public int CurrentHealth
    {
        get => currentHealth;
    }

    /// <summary>
    /// Returns true if the player can be damaged.
    /// </summary>
    /// <returns></returns>
    public bool CanDamage() //Takes invincibility frames into account, but can be expanded upon if necessary.
    {
        return invincibilityTime <= 0;
    }

    /// <summary>
    /// Tries to damage the player. An OnDamaged event will be called with a parameter telling the listener if the hit landed.
    /// </summary>
    /// <exception cref="If the player dies, an OnDeath event will be called instead of an OnDamaged event."/> //Lol I know this is not what the exception element is for, I just find it funny.
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        bool canDamage = CanDamage();
        if (canDamage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                OnDeath();
            }
        }
        if (currentHealth > 0)
        {
            OnDamaged(canDamage);
        }
    }

    private void FixedUpdate()
    {
        if (invincibilityTime > 0)
        {
            invincibilityTime -= Time.deltaTime;
        }
    }
}
