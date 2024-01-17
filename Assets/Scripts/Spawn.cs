using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform spawnPoint;
    public DamageableObject spawnObject;
    public float delaySpawnTime;
    private HealthSystem hs;
    public GameObject deathText;

    private void Start()
    {
        if (spawnPoint == null)
        {
            spawnPoint = spawnObject.transform;
        }

        hs = spawnObject.GetComponent<HealthSystem>();
        hs.Death += OnDeath;
    }

    private void OnDeath(GameObject target)
    {
        spawnObject.gameObject.SetActive(false);
        ActiveUI(true);
        StartCoroutine(Delay());
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delaySpawnTime);
        hs.FullRestore();
        ActiveUI(false);
        spawnObject.transform.position =
            new Vector3(spawnPoint.position.x, spawnObject.transform.position.y, spawnPoint.position.z);
        spawnObject.gameObject.SetActive(true);
    }

    private void ActiveUI(bool textOn)
    {
        if (spawnObject.GetComponent<BasePlayer>() != null)
        {
            deathText.SetActive(textOn);
        }
    }
}