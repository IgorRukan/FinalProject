using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public float healValue;
    
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<BasePlayer>())
        {
            other.gameObject.GetComponent<BasePlayer>().GetComponent<HealthSystem>().AddHealth(healValue);
        }
    }
}