using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float ShootingRate;
    public PerceptionComponent pc;

    public DamageableObject target;
    private float time;
    public Transform shootPos;

    public bool inRange;

    private Animations animations;

    private void Start()
    {
        pc = GetComponent<PerceptionComponent>();
        animations = GetComponent<Animations>();
    }

    public void Shooting()
    {
        if (target == null)
        {
            return;
        }

        //shootPos.transform.position
        var position = transform.position;
        Vector3 dir = target.transform.position - position;
        Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);

        Instantiate(bullet, position, rotation);
    }

    private void IsInRange()
    {
        if (target == null)
            return;
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= pc.smallDistance)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }

    private void Update()
    {
        target = pc.GetTarget();
        IsInRange();
        if (target == null)
        {
            GetComponent<Animations>().AttackAnimation(false);
            return;
        }

        time += Time.deltaTime;

        if (animations.movement == Vector3.zero)
        {
            GetComponent<Animations>().AttackAnimation(true);
            //Debug.Break();

            if (time > ShootingRate)
            {
                Shooting();
                transform.LookAt(target.transform);
                time -= ShootingRate;
            }
        }
        else
        {
            GetComponent<Animations>().AttackAnimation(false);
        }
    }
}