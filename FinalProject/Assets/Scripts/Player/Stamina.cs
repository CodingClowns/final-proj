using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class adds stamina functionality. Stamina can be drained continuously at a set rate or deducted instantly.
/// </summary>
public class Stamina : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private float maxStamina;

    [Min(0)]
    [SerializeField] private float maxRechargeTime;
    
    private float rechargeTime = 0;

    public float CurrentStamina { get; set; }

    /// <summary>
    /// Should be called once every update. Manages the stamina recharge mechanic.
    /// </summary>
    private void ManageRecharge()
    {
        if (CurrentStamina <= 0)
        {
            rechargeTime += Time.deltaTime;

            if (rechargeTime >= maxRechargeTime)
            {
                rechargeTime = 0;
                CurrentStamina = maxStamina;
            }
        }
    }

    private void FixedUpdate()
    {
        ManageRecharge();
    }
}
