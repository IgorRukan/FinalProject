using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CreateItems : MonoBehaviour
{
    public enum Type
    {
        Head,
        Armor,
        Trousers,
        Tshirt,
        Gloves,
        Boots,
        Ring,
        Weapon,
        InventorySlot
    }

    public enum Quality
    {
        Grey,
        Green,
        Blue,
        Purple,
        Gold,
        Orange
    }

    private Type type;

    private Quality quality = Quality.Grey;

    public StatsCreateRange statsCreate;
    public StatsCreateRange statsCreateGrey;
    public StatsCreateRange statsCreateGreen;
    public StatsCreateRange statsCreateBlue; 
    public StatsCreateRange statsCreatePurple;
    public StatsCreateRange statsCreateGold;
    public StatsCreateRange statsCreateOrange;
        
    public void SetStats(Stats stats, Items item)
    {
        type = GetRandomEnumValue(Type.Head, Type.Weapon);

        CreateQuality();
        
        Stats.Stat randStat1 = Stats.Stat.armor;
        Stats.Stat randStat2 = Stats.Stat.armor;
        float randValueOfStat1 = 0f;
        float randValueOfStat2 = 0f;
        
        switch (type)
        {
            case Type.Head:
            {
                randStat1 = Stats.Stat.crit;
                randStat2 = Stats.Stat.critChance;
                randValueOfStat1 = Random.Range(statsCreate.critMin, statsCreate.critMax);
                randValueOfStat2 = Random.Range(statsCreate.critChanceMin, statsCreate.critChanceMax);
                break;
            }
            case Type.Armor:
            {
                randStat1 = Stats.Stat.armor;
                randStat2 = Stats.Stat.maxHealth;
                randValueOfStat1 = Random.Range(statsCreate.armorMin, statsCreate.armorMax);
                randValueOfStat2 = Random.Range(statsCreate.maxHealthMin, statsCreate.maxHealthMax);
                break;
            }
            case Type.Trousers:
            {
                randStat1 = Stats.Stat.axeDamage;
                randStat2 = Stats.Stat.attackRange;
                randValueOfStat1 = Random.Range(statsCreate.axeDamageMin, statsCreate.axeDamageMax);
                randValueOfStat2 = Random.Range(statsCreate.attackRangeMin, statsCreate.attackRangeMax);
                break;
            }
            case Type.Boots:
            {
                randStat1 = Stats.Stat.speed;
                randStat2 = Stats.Stat.damage;
                randValueOfStat1 = Random.Range(statsCreate.speedMin, statsCreate.speedMax);
                randValueOfStat2 = Random.Range(statsCreate.damageMin, statsCreate.damageMax);
                break;
            }
            case Type.Weapon:
            {
                randStat1 = Stats.Stat.attackSpeed;
                randStat2 = Stats.Stat.lifesteal;
                randValueOfStat1 = Random.Range(statsCreate.attackSpeedMin, statsCreate.attackSpeedMax);
                randValueOfStat2 = Random.Range(statsCreate.lifestealMin, statsCreate.lifestealMax);
                break;
            }
            case Type.Ring:
            {
                randStat1 = Stats.Stat.hpRegen;
                randStat2 = Stats.Stat.bonusExp;
                randValueOfStat1 = Random.Range(statsCreate.armorMin, statsCreate.armorMax);
                randValueOfStat2 = Random.Range(statsCreate.bonusExpMin, statsCreate.bonusExpMax);
                break;
            }
        }

        stats.AddStat(randStat1, randValueOfStat1);
        stats.AddStat(randStat2, randValueOfStat2);

        Stats.Stat[] statMas = new Stats.Stat[2];
        float[] statV = new float[2];
        
        statMas[0] = randStat1;
        statMas[1] = randStat2;

        statV[0] = randValueOfStat1;
        statV[1] = randValueOfStat2;

        item.SetParam(type,quality,statMas,statV);
    }

    private void CreateQuality()
    {
        var value = Random.Range(0f, 100f);
        if (value < statsCreateBlue.orangeQualityChanse)
        {
            quality = Quality.Orange;
            statsCreate = statsCreateOrange;
        }

        if (value < statsCreateBlue.goldQualityChanse)
        {
            quality = Quality.Gold;
            statsCreate = statsCreateGold;
        }

        if (value < statsCreateBlue.purpleQualityChanse)
        {
            quality = Quality.Purple;
            statsCreate = statsCreatePurple;
        }

        if (value < statsCreateBlue.blueQualityChanse)
        {
            quality = Quality.Blue;
            statsCreate = statsCreateBlue;
        }

        if (value < statsCreateBlue.greenQualityChanse)
        {
            quality = Quality.Green;
            statsCreate = statsCreateGreen;
        }

        if (quality.Equals(Quality.Grey))
        {
            statsCreate = statsCreateGrey;
        }
    }

    private T GetRandomEnumValue<T>(T minValue, T maxValue)
    {
        Array values = Enum.GetValues(typeof(T));
        int minIndex = Array.IndexOf(values, minValue);
        int maxIndex = Array.IndexOf(values, maxValue);
        int randomIndex = Random.Range(minIndex, maxIndex + 1);
        return (T)values.GetValue(randomIndex);
    }
}