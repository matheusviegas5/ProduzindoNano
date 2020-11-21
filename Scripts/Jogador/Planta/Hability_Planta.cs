﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hability_Planta : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && IsOnLight.isOnLight && !Configuration.isPaused)
        {
            animator.SetBool("Power", true);
        }
    }

    private void FixedUpdate()
    {
        animator.SetBool("Power", false);
    }
}
