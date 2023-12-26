using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public float ShootingRate;
    public PerceptionComponent pc;

    private DamageableObject enemy;
    private float time;

    private void Start()
    {
        pc = GetComponent<PerceptionComponent>();
    }

    public void Shoot()
    {
        enemy = pc.GetTarget();
        if (enemy == null)
            return;
    
        var position = transform.position;
        Vector3 dir = enemy.transform.position - position;
        Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);

        Instantiate(bullet, position, rotation);
    }

    private void Update()
    {
        enemy = pc.GetTarget();
        
        time += Time.deltaTime;
        if (time > ShootingRate)
        {
            Shoot();
            time -= ShootingRate;
        }
    }
}
