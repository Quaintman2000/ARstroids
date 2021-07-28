using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Pickup : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Projectile>() != null)
        {
            ApplyEffect(other.GetComponent<Projectile>());
        }
        Destroy(this.gameObject);
    }
    protected abstract void ApplyEffect(Projectile projectile);
}
