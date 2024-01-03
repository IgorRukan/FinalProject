using System;
using UnityEngine;
using UnityEngine.Serialization;

public class FightAI : MonoBehaviour
{
    
    public GameObject target;
    private MovementComponent mc;

    private void Start()
    {
        mc = GetComponent<MovementComponent>();
    }

    private void Update()
    {
        if (target.Equals(null))
        {
            return;
        }
        target = GetComponent<PerceptionComponent>().GetTarget().gameObject;
        Fight();
    }

    private void Fight()
    {
        Attack(target);
    }

    private void Attack(GameObject opponent1)
    {
        if (!GetComponent<Shoot>().inRange)
        {
            Vector3 direction = opponent1.transform.position - transform.position;

            direction.Normalize();
            
            GetComponent<MovementComponent>().Move(direction);
        }

        transform.LookAt(opponent1.transform);
    }
}