using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    
    public Transform spawnPoint;
    public DamageableObject spawnObject;
    public float delaySpawnTime;

    private void Start()
    {
        if (spawnPoint == null)
        {
            spawnPoint = transform;
        }
        spawnObject.GetComponent<HealthSystem>().Death += OnDeath;
    }

    private void OnDeath(GameObject target)
    {
        spawnObject.gameObject.SetActive(false);
        spawnObject.transform.position = new Vector3(spawnPoint.position.x,spawnObject.transform.position.y,spawnPoint.position.z);
        StartCoroutine(Delay());

    }


    IEnumerator Delay()
    {
        Debug.Log("Delay");
        yield return new WaitForSeconds(delaySpawnTime);
        spawnObject.gameObject.SetActive(true);
    }
}
