using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StatsCreateRange", order = 1)]
public class StatsCreateRange : ScriptableObject
{
    public float damageMin; 
    public float damageMax; 
    public float armorMin; 
    public float armorMax; 
    public float lifestealMin;
    public float lifestealMax;
    public float speedMin; 
    public float speedMax; 
    public float attackRangeMin; 
    public float attackRangeMax;
    public float attackSpeedMin; 
    public float attackSpeedMax; 
    public float maxHealthMin; 
    public float maxHealthMax; 
    public float hpRegenMin; 
    public float hpRegenMax; 
    public float critMin; 
    public float critMax; 
    public float critChanceMin; 
    public float critChanceMax; 
    public float bonusExpMin; 
    public float bonusExpMax; 
    public float axeDamageMin; 
    public float axeDamageMax;
    public float orangeQualityChanse;
    public float goldQualityChanse;
    public float purpleQualityChanse;
    public float blueQualityChanse;
    public float greenQualityChanse;
}
