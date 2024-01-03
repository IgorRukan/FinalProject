using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackRange;
    public PerceptionComponent pc;
    public DamageableObject target;

    public Animator animator;

    public bool inRange = false;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    private void Start()
    {
        pc = GetComponent<PerceptionComponent>();
    }

    private void Update()
    {
        target = pc.GetTarget();
        IsInRange();
        if (inRange)
        {
            animator.SetTrigger("MeleeAttack");
        }
    }

    private void IsInRange()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= attackRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }
}
