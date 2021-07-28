using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAmmoPickup : Pickup
{
    [SerializeField, Tooltip("The amount of rockets to add.")]
    int rocketsToAdd;

    protected override void ApplyEffect(Projectile projectile)
    {
        projectile.shooter.GetComponent<Pawn>().AddAmmo(rocketsToAdd);
    }
}
