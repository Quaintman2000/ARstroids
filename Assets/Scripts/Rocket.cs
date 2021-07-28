﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Projectile
{
    // Start is called before the first frame update
    [SerializeField, Tooltip("The target the rocket follows.")]
    private GameObject target;
    [SerializeField]
    float maxVelocity = 5;
    [SerializeField]
    float maxTurnSpeed = 5;

    Pawn[] players = new Pawn[2];
    protected override void Start()
    {
        players = FindObjectsOfType<Pawn>();

        foreach (Pawn player in players)
        {
            if (player.gameObject != shooter)
            {
                target = player.gameObject;
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            FollowTarget(target.transform);
        }
        transform.position += transform.forward * maxVelocity * Time.deltaTime;
    }

    public void FollowTarget(Transform targetToFollow)
    {
        Vector3 vectorToTarget = targetToFollow.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget);
        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, maxTurnSpeed * Time.deltaTime);
    }
}