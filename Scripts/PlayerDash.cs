﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float DashSpeed = 90f;

    

    private PlayerMovement Player;
    private Animator animator;
    private bool candash=true;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.GetComponent<PlayerMovement>();
        animator= this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (candash){
            Vector2 Movement = new Vector2(Player.lastMoveHorizontal, Player.lastMoveVertical).normalized;
            Player.Walk(Movement, DashSpeed);
            animator.SetBool("Dash",true);
            StartCoroutine(dashcooldown());
            }

        }

        
    }

    IEnumerator dashcooldown(){
        candash=false;
        yield return new WaitForSeconds(0.35f);
        animator.SetBool("Dash",false);
        yield return new WaitForSeconds(0.2f);
        candash=true;

    }
}
