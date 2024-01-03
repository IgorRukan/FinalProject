using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float ShootingRate;
    public PerceptionComponent pc;

    private DamageableObject target;
    private float time;

    public bool inRange;

    private void Start()
    {
        pc = GetComponent<PerceptionComponent>();
    }

    public void Shooting()
    {
        target = pc.GetTarget();
        if (target == null)
            return;
    
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
        time += Time.deltaTime;
        if (time > ShootingRate)
        {
            Shooting();
            time -= ShootingRate;
        }
    }
}
