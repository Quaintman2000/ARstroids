using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField,Tooltip("The amount of health the pawn will gain when picked up.")]
    float healthToGain;

    protected override void ApplyEffect(Projectile projectile)
    {
        projectile.shooter.GetComponent<Health>().health += 15;
    }
}
