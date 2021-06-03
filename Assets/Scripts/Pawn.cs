using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    // Variables with tool tips.
    [Tooltip("Amount of health the player has. Nonregenable")]
    public float health = 100f;
    [Tooltip("The defualt fire rate of the player's guns.")]
    [SerializeField] private protected float fireRate = 5.0f;
    [Tooltip("Amount of shields of the player. Regenable")]
    [SerializeField] private float sheilds = 100f;
    [Tooltip("Amount of Energy/Power the player has.")]
    [SerializeField] private protected float power;

    [SerializeField] private protected Transform firePoint;
    [SerializeField]
    private protected GameObject bulletPrefab;
    /// <summary>
    /// Reduces the health and shields of the player. It removes the shields first then the health.
    /// </summary>
    /// <param name="damageDealt">The amount of damage an porjectile or attack deals.</param>
    public void TakeDamage(float damageDealt)
    {
        // If damage dealt is greater than the amount sheilds the player has...
        if(damageDealt > sheilds)
        {
            // Calculate the leftover damage after sheilds have been zeroed.
            float dmgLeftOver = damageDealt - sheilds;

            // Zero out sheilds.
            sheilds = 0;

            // Subtract health from the leftover damage dealt.
            health -= dmgLeftOver;
        }
        // If damage dealt is < the amount of sheilds the player has...
        else
        {
            // Subtract sheilds from damage dealt.
            sheilds -= damageDealt;
        }
    }

    public void Shoot(GameObject projectile)
    {
        // Instaniates the projectile at the firepoint postion facing the same way as the fire point.
        Instantiate(projectile, firePoint.position, firePoint.rotation);
        // Play sound.
    }

}
