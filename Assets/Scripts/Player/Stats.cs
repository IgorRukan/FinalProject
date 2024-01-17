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
    public float crit; // only buy
    public float critChance; // only buy
    public float bonusExp; // only buy
    public float axeDamage; // only buy
    public float axeSpeed; // only buy
    public float pickaxeDamage; // only buy
    public float pickaxeSpeed; // only buy

    public float wood;

    public bool isMinening = false;

    private void Start()
    {
        if (bigAttackRange == 0)
        {
            BigRangeCheck();
        }

        if (GetComponent<BasePlayer>() != null)
        {
            GetComponent<Experience>().LvlUp += LevelUp;
        }
    }

    public void LevelUp()
    {
        AddStat("damage", 1);
        AddStat("armor", 0.05f);
        AddStat("speed", 0.005f);
        AddStat("attackRange", 0.1f);
        AddStat("attackSpeed", -0.01f);
        BigRangeCheck();
    }

    public void AddStat(string statName, float value)
    {
        var field = GetType().GetField(statName);

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