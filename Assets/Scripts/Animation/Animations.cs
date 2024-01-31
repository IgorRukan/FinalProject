using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator animator;

    private float speed;

    public Vector3 movement;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (movement != Vector3.zero)
        {
            speed = 0.5f;
        }
        if (movement == Vector3.zero)
        {
            speed = 0f;
        }

        animator.SetFloat("Speed", speed);
    }

    public void SetMovement(Vector3 newMovement)
    {
        movement = newMovement;
    }
    
    public void AttackAnimation(bool attackState)
    {
        animator.SetTrigger(attackState ? "Attack" : "StopAttack");
    }

    public void MineTreeAnimation(bool mineState)
    {
        animator.SetTrigger(mineState ? "MineTree" : "StopMining");
    }

    public void StopCurrentAnimation()
    {
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        animator.StopPlayback();
    }
}
