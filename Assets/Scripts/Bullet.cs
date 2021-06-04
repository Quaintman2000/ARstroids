using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField] Rigidbody rgbd;
    [SerializeField] float projectileForce;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();

        rgbd.AddForce(transform.forward * projectileForce);
    }
}
