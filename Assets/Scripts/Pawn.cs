using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    
    [Tooltip("The defualt fire rate of the player's guns.")]
    [SerializeField] private protected float fireRate = 5.0f;
    
    [Tooltip("Amount of Energy/Power the player has.")]
    [SerializeField] private protected float power;
    [SerializeField] private protected int ammo, ammoReserves;

    [SerializeField] private protected Transform firePoint;
    [SerializeField]
    private protected GameObject bulletPrefab;
   

    public void Shoot()
    {
        // Instaniates the projectile at the firepoint postion facing the same way as the fire point.
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        newBullet.GetComponent<Bullet>().shooter = this.gameObject;
        // Play sound.
    }

    

}
