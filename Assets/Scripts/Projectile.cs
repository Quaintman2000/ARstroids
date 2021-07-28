using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rgbd;
    [SerializeField] float projectileForce;
    // Variables needed for projectiles.
    [SerializeField] private protected float damage, lifeSpan;
    public GameObject shooter;

    protected virtual void Start()
    {
        rgbd = GetComponent<Rigidbody>();

        rgbd.AddForce(transform.forward * projectileForce);
    }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Health>() != null & other.gameObject != shooter)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }

}
