using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class StatsSave 
{
    public float damage; 
    public float armor; 
    public float lifesteal; 
    public float speed; 
    public float attackRange; 
    public float bigAttackRange;
    public float attackSpeed; 
    public float maxHealth; 
    public float hpRegen;
    public float crit; 
    public float critChance; 
    public float bonusExp; 
    public float axeDamage; 
    public float axeSpeed; 
    public float pickaxeDamage;
    public float pickaxeSpeed; 
    
    public bool isMinening = false;

    public Stats.Stat itemFirstStat;
    public Stats.Stat itemSecondStat;
}
