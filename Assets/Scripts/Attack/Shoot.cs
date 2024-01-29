using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float shootingRate;
    public PerceptionComponent pc;

    public DamageableObject target;
    private float time;
    public Transform shootPos;

    public bool inRange;

    private Animations animations;

    public DamageableObject current;
    
    private Stats stats;
    
    public AmmoPool pool;
    private void Start()
    {
        pc = GetComponent<PerceptionComponent>();
        animations = GetComponent<Animations>();
        stats = GetComponent<Stats>();
        current = GetComponent<DamageableObject>();
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

        var bul = pool.GetPooledObjects();
        bul.GetComponent<DamageSystem>().damageAmount = GetComponent<StatImpact>().GetBulletDamage();
        bul.gameObject.SetActive(true);
        bul.transform.position = position;
        bul.transform.rotation = rotation;

        bul.SetTarget(target.transform);
        bul.Shoot(dir);
    }

    private void IsInRange()
    {
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
        if (target == null)
        {
            GetComponent<Animations>().AttackAnimation(false);
            return;
        }
        IsInRange();

        time += Time.deltaTime;

        if (animations.movement == Vector3.zero)
        {
            GetComponent<Animations>().AttackAnimation(true);

            shootingRate = stats.attackSpeed;
            
            if (time > shootingRate)
            {
                Shooting();
                transform.LookAt(target.transform);
                time = 0;
            }
        }
        else
        {
            GetComponent<Animations>().AttackAnimation(false);
        }
    }
}