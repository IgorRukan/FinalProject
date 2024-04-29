using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StatImpact : MonoBehaviour
{
    public Stats stats;
    public HealthSystem hs;
    private void Start()
    {
        stats = GetComponent<Stats>();
        hs = GetComponent<HealthSystem>();
        if (GetComponent<BasePlayer>())
        {
            stats = StatManager.Instance.currentStats;
        }

        if (GetComponent<BasePlayer>())
        {
            GetComponent<Experience>().LvlUp += LevelUp;
        }
    }

    private void LevelUp()
    {
        SetAutoHeal();
    }

    public void GetDamage(float value)
    {
        var crit = Random.Range(0, 100);
        var critDamage = 0f;
        if (stats.critChance >= crit)
        {
            critDamage = stats.crit;
        }

        hs.currentHealth -= value + value * (critDamage / 100f) - stats.armor * value;
    }
    
    public void LifeSteal()
    {
        hs.currentHealth += stats.lifesteal * stats.damage;
    }

    public void SetAutoHeal()
    {
        hs.AutoHealValue = stats.hpRegen;
    }

    public float GetMaxHealth()
    {
        return stats.currentHp;
    }

    public float GetBulletDamage()
    {
        return stats.damage;
    }

    public float GetSpeed()
    {
        return stats.speed;
    }

    private void Update()
    {
        SetAutoHeal();
    }
}
