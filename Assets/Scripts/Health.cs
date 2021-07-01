using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Variables with tool tips.
    [Tooltip("Amount of health the player has. Nonregenable")]
    public float health = 100f;
    public float maxHealth = 100f;
    [Tooltip("Amount of shields of the player. Regenable")]
    [SerializeField] private float sheilds = 100f;
    /// <summary>
    /// Reduces the health and shields of the player. It removes the shields first then the health.
    /// </summary>
    /// <param name="damageDealt">The amount of damage an porjectile or attack deals.</param>
    public void TakeDamage(float damageDealt)
    {
        // If damage dealt is greater than the amount sheilds the player has...
        if (damageDealt > sheilds)
        {
            // Calculate the leftover damage after sheilds have been zeroed.
            float dmgLeftOver = damageDealt - sheilds;

            // Zero out sheilds.
            sheilds = 0;

            // Subtract health from the leftover damage dealt.
            health -= dmgLeftOver;

            if (health <= 0)
            {
                Die();
            }
        }
        // If damage dealt is < the amount of sheilds the player has...
        else
        {
            // Subtract sheilds from damage dealt.
            sheilds -= damageDealt;
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
