using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionComponent : MonoBehaviour
{
    public LayerMask targetMask;
    public float smallDistance;
    public float bigDistance;
    public float SearchRadius;
    public GameObject closestObj;
    public List<GameObject> targets;

    public LayerMask nearEnemyMask;
    public float nearestEnemyDistance;
    public List<GameObject> nearestEnemy;

    private Stats stats;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    private void Update()
    {
        GetTargets(targetMask,targets,SearchRadius);
        GetTargets(nearEnemyMask,nearestEnemy,nearestEnemyDistance);
        ClosestTarget();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, smallDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, bigDistance);
    }

    private void GetTargets(LayerMask target, List<GameObject> targetList,float searchRadius)
    {
        var objectsInRadius = Physics.OverlapSphere(transform.position, searchRadius);

        for (int i = 0; i < objectsInRadius.Length; i++)
        {
            if ((target.value & (1 << objectsInRadius[i].gameObject.layer)) != 0)
            {
                if (targetList.Contains(objectsInRadius[i].gameObject))
                {
                    continue;
                }

                targetList.Add(objectsInRadius[i].gameObject);
            }
        }

        foreach (var tar in targets)
        {
            tar.GetComponent<HealthSystem>().Death += OnDeath;
        }
    }

    private void OnDeath(GameObject target)
    {
        targets.Remove(target);
        if (target == closestObj)
        {
            closestObj = null;
        }

        target.GetComponent<HealthSystem>().Death -= OnDeath;
    }

    public DamageableObject GetTarget()
    {
        ClosestTarget();
        if (closestObj == null)
        {
            return null;
        }
        return closestObj.GetComponent<DamageableObject>();
    }

    public void SetTarget(DamageableObject target)
    {
        closestObj = target.gameObject;
    }

    private void ClosestTarget()
    {
        smallDistance = stats.attackRange;
        bigDistance = stats.bigAttackRange;
        
        bool inRange = false;
        float closestDistance = Mathf.Infinity;
        foreach (var target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance <= smallDistance && distance < closestDistance)
            {
                closestObj = target.gameObject;
                closestDistance = distance;
                inRange = true;
            }
        }

        if (!inRange && closestObj != null)
        {
            float distance = Vector3.Distance(transform.position, closestObj.transform.position);
            if (distance <= bigDistance)
            {
                inRange = true;
            }

            if (!inRange)
            {
                closestObj = null;
            }
        }
    }
}