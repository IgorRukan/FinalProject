using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float damage; // lvl +1
    public float armor; // lvl +0.05
    public float lifesteal; // only buy
    public float speed; // lvl + 0.005
    public float attackRange; // lvl + 0.1
    public float bigAttackRange;
    public float attackSpeed; // lvl + hz
    public float maxHealth; // lvl + 50hp
    public float hpRegen; // lvl + 0.5hp
    public float crit; // only buy
    public float critChance; // only buy
    public float bonusExp; // only buy
    public float axeDamage; // only buy
    public float axeSpeed; // only buy
    public float pickaxeDamage; // only buy
    public float pickaxeSpeed; // only buy

    public float wood;

    public bool isMinening = false;

    public enum Stat
    {
        damage,
        armor,
        lifesteal,
        speed,
        attackRange,
        attackSpeed,
        maxHealth,
        hpRegen,
        crit,
        critChance,
        bonusExp,
        axeDamage,
        axeSpeed,
        pickaxeDamage,
        pickaxeSpeed,
        wood
    }

    private void Start()
    {
        if (bigAttackRange == 0)
        {
            BigRangeCheck();
        }

        if (GetComponent<StatManager>())
        {
            ObjectsManager.Instance.player.GetComponent<Experience>().LvlUp += LevelUp;
        }
    }

    public void LevelUp()
    {
        AddStat(Stat.damage, 1);
        AddStat(Stat.armor, 0.05f);
        AddStat(Stat.lifesteal, 0.05f);
        AddStat(Stat.speed, 0.005f);
        AddStat(Stat.attackRange, 0.1f);
        AddStat(Stat.attackSpeed, -0.01f);
        AddStat(Stat.hpRegen, 0.5f);
        AddStat(Stat.maxHealth,maxHealth);
        BigRangeCheck();
    }

    public void AddAllStats(Stats addedStats, bool add)
    {
        float sign;
        if (add)
        {
            sign = 1f;
        }
        else
        {
            sign = -1f;
        }

        AddStat(Stat.damage, sign * addedStats.damage);
        AddStat(Stat.armor, sign * addedStats.armor);
        AddStat(Stat.speed, sign * addedStats.speed);
        AddStat(Stat.attackRange, sign * addedStats.attackRange);
        AddStat(Stat.attackSpeed, sign * addedStats.attackSpeed);
        AddStat(Stat.hpRegen, sign * addedStats.hpRegen);
        AddStat(Stat.maxHealth, sign * addedStats.maxHealth);
        AddStat(Stat.crit, sign * addedStats.crit);
        AddStat(Stat.critChance, sign * addedStats.critChance);
        AddStat(Stat.bonusExp, sign * addedStats.bonusExp);
        AddStat(Stat.axeDamage, sign * addedStats.axeDamage);
        AddStat(Stat.axeSpeed, sign * addedStats.axeSpeed);
        AddStat(Stat.pickaxeDamage, sign * addedStats.pickaxeDamage);
        AddStat(Stat.pickaxeSpeed, sign * addedStats.pickaxeSpeed);
    }

    public void AddStat(Stat statName, float value)
    {
        var field = GetType().GetField(statName.ToString());

        if (field != null && field.FieldType == typeof(float))
        {
            var currentValue = (float)field.GetValue(this);

            var newValue = currentValue + value;

            field.SetValue(this, newValue);
        }
        else
        {
            Debug.LogError("Invalid stat name or type: " + statName);
        }
    }

    private void BigRangeCheck()
    {
        bigAttackRange = attackRange;
    }
}