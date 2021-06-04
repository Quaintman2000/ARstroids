﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : Pawn
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Keeps track of all the inputs.
        // On mouse click...
        if(Input.GetMouseButtonDown(0))
        {
            // Shoots bullet prefabs.
            Shoot(projectile: bulletPrefab);
        }
    }
}