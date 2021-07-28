using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Pawn : MonoBehaviour
{ 
    Health health;

    [Tooltip("The defualt fire rate of the player's guns.")]
    [SerializeField] private protected float fireRate = 5.0f;

    [SerializeField] public int rockets;

    [SerializeField] private protected Transform firePoint;
    [SerializeField]
    private protected GameObject bulletPrefab;
    [SerializeField]
    protected GameObject rocketPrefab;

    private void Start()
    {
        health = GetComponent<Health>();
    }
    public void Shoot()
    {
        // Instaniates the projectile at the firepoint postion facing the same way as the fire point.
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        newBullet.GetComponent<Projectile>().shooter = this.gameObject;
        // Play sound.
    }

    public void fireRocket()
    {
        if (rockets > 0)
        {
            // Instaniates the projectile at the firepoint postion facing the same way as the fire point.
            GameObject newRocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
            newRocket.GetComponent<Projectile>().shooter = this.gameObject;
            // Play sound.
        }
        else
        {
            //Todo: play dummy sounds
        }
    }
    
    /// <summary>
    /// When called, adds set ammo to rockets variable.
    /// </summary>
    /// <param name="ammoToAdd">Number of rockets to add.</param>
    public void AddAmmo(int ammoToAdd)
    {
        rockets += ammoToAdd;
    }

}
