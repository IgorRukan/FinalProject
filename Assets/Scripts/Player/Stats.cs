using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
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
    public float currentHp; // lvl + 50hp
    public float hpRegen; // lvl + 0.5hp
    public float crit; // only buy
    public float critChance; // only buy
    public float bonusExp; // only buy
    public float axeDamage; // only buy
    public float axeSpeed; // only buy
    public float pickaxeDamage; // only buy
    public float pickaxeSpeed; // only buy
    
    public bool isMinening = false;
    public bool isFight = false;

    public Stat itemFirstStat;
    public Stat itemSecondStat;
    

    public enum Stat
    {
        damage,
        armor,
        lifesteal,
        speed,
        attackRange,
        attackSpeed,
        maxHealth,
        currentHp,
        hpRegen,
        crit,
        critChance,
        bonusExp,
        axeDamage,
        axeSpeed,
        pickaxeDamage,
        pickaxeSpeed
    }

    private void Start()
    {
        if (bigAttackRange == 0)
        {
            BigRangeCheck();
        }
        
        if (GetComponent<BasePlayer>())
        {
            ObjectsManager.Instance.player.GetComponent<Experience>().LvlUp += LevelUp;
        }
    }

    public void LevelUp()
    {
        Stats statsPerLevel = StatManager.Instance.GetStatAddedPerLvl();
        Debug.Log(statsPerLevel);
        AddStat(Stat.damage, statsPerLevel.damage);
        AddStat(Stat.armor, statsPerLevel.armor);
        AddStat(Stat.lifesteal, statsPerLevel.lifesteal);
        AddStat(Stat.speed, statsPerLevel.speed);
        AddStat(Stat.attackRange, statsPerLevel.attackRange);
        AddStat(Stat.attackSpeed, statsPerLevel.attackSpeed);
        AddStat(Stat.hpRegen, statsPerLevel.hpRegen);
        AddStat(Stat.maxHealth,maxHealth);
        
        BigRangeCheck();
        
        StatManager.Instance.SetPlayerStats(statsPerLevel);
    }

    public float StatValue(Stat statName)
    {
        float value = 0f;
        
        var field = GetType().GetField(statName.ToString());
        
        if (field != null && field.FieldType == typeof(float))
        {
            value = (float)field.GetValue(this);
        }
        
        return value;
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
        AddStat(Stat.currentHp, sign * addedStats.currentHp);
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

    public void SetParam(StatsSave playerStats)
    {
        damage = playerStats.damage;
        attackSpeed = playerStats.attackSpeed;
        attackRange = playerStats.attackRange;
        crit = playerStats.crit;
        critChance = playerStats.critChance;
        speed = playerStats.speed;
        armor = playerStats.armor;
        maxHealth = playerStats.maxHealth;
        hpRegen = playerStats.hpRegen;
        lifesteal = playerStats.lifesteal;
        currentHp = playerStats.currentHp;
        bonusExp = playerStats.bonusExp;
        axeDamage = playerStats.axeDamage;
        axeSpeed = playerStats.axeSpeed;
        pickaxeDamage = playerStats.pickaxeDamage;
        pickaxeSpeed = playerStats.pickaxeSpeed;
        isMinening = false;
        itemFirstStat = Stat.armor;
        itemSecondStat = Stat.armor;
        
    }

    private void BigRangeCheck()
    {
        bigAttackRange = attackRange;
    }
}