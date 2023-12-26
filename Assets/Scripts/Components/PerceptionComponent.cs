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
    private void Update()
    {
        GetTargets();
        ClosestTarget();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, smallDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, bigDistance);
    }

    private void GetTargets()
    {
        var objectsInRadius = Physics.OverlapSphere(transform.position, SearchRadius);

        for (int i = 0; i < objectsInRadius.Length; i++)
        {
            if ((targetMask.value & (1 << objectsInRadius[i].gameObject.layer)) != 0)
            {
                if (targets.Contains(objectsInRadius[i].gameObject))
                {
                    continue;
                }

                targets.Add(objectsInRadius[i].gameObject);
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

    private void ClosestTarget()
    {
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