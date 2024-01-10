using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float strength;
    public float agility;
    public float intelligence;
    public float armor;
    public float lifesteal;
    public float speed;
    public float attackRange;
    public float attackSpeed;
    public float crit;
    public float critChance;
    public float bonusExp;
    public float axeDamage;
    public float axeSpeed;
    public float pickaxeDamage;
    public float pickaxeSpeed;
    
    public float wood;

    public bool isMinening = false;


    public void AddStat(string statName,float value)
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
}
