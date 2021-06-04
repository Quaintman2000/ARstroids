using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Variables needed for projectiles.
    [SerializeField] private protected float damage, lifeSpan;
    public GameObject shooter;

    private void Update()
    {
        // If the lifespan timer is less than 0,
        if (lifeSpan <= 0)
        {
            // Die
            Destroy(this.gameObject);
        }
        else
        {
            // Subtract the lifespan by time.
            lifeSpan -= Time.deltaTime;
        }
    }

    // One collision with another object.
    private void OnCollisionEnter(Collision collision)
    {
        // If the object is tagged as a player
        if (collision.gameObject.tag == "Player")
        {
            // Send message to deal damage.
            collision.gameObject.SendMessage("TakeDamage", damage);
        }
        else
        {
            // Die.
            Destroy(this.gameObject);
        }
    }

}
