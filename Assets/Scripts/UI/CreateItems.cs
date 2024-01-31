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
        Bracer,
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

    public ItemCreateIcons itemIconsAndColors;
        
    public void SetStats(Stats stats, Items item)
    {
        type = GetRandomEnumValue(Type.Head, Type.Weapon);

        Stats.Stat randStat1 = Stats.Stat.armor;
        Stats.Stat randStat2 = Stats.Stat.armor;
        float randValueOfStat1 = 0f;
        float randValueOfStat2 = 0f;
        Sprite backgroundColor = CreateQuality();
        Sprite icon = null;
        
        switch (type)
        {
            case Type.Head:
            {
                randStat1 = Stats.Stat.crit;
                randStat2 = Stats.Stat.critChance;
                randValueOfStat1 = Random.Range(statsCreate.critMin, statsCreate.critMax);
                randValueOfStat2 = Random.Range(statsCreate.critChanceMin, statsCreate.critChanceMax);
                icon = itemIconsAndColors.headIcon;
                break;
            }
            case Type.Armor:
            {
                randStat1 = Stats.Stat.armor;
                randStat2 = Stats.Stat.maxHealth;
                randValueOfStat1 = Random.Range(statsCreate.armorMin, statsCreate.armorMax);
                randValueOfStat2 = Random.Range(statsCreate.maxHealthMin, statsCreate.maxHealthMax);
                icon = itemIconsAndColors.armorIcon;
                break;
            }
            case Type.Gloves:
            {
                randStat1 = Stats.Stat.attackSpeed;
                randStat2 = Stats.Stat.critChance;
                randValueOfStat1 = Random.Range(statsCreate.attackSpeedMin, statsCreate.attackSpeedMax);
                randValueOfStat2 = Random.Range(statsCreate.critChanceMin, statsCreate.critChanceMax);
                icon = itemIconsAndColors.glovesIcon;
                break;
            }
            case Type.Bracer:
            {
                randStat1 = Stats.Stat.maxHealth;
                randStat2 = Stats.Stat.hpRegen;
                randValueOfStat1 = Random.Range(statsCreate.maxHealthMin, statsCreate.maxHealthMax);
                randValueOfStat2 = Random.Range(statsCreate.hpRegenMin, statsCreate.hpRegenMax);
                icon = itemIconsAndColors.bracerIcon;
                break;
            }
            case Type.Trousers:
            {
                randStat1 = Stats.Stat.axeDamage;
                randStat2 = Stats.Stat.attackRange;
                randValueOfStat1 = Random.Range(statsCreate.axeDamageMin, statsCreate.axeDamageMax);
                randValueOfStat2 = Random.Range(statsCreate.attackRangeMin, statsCreate.attackRangeMax);
                icon = itemIconsAndColors.trousersIcon;
                break;
            }
            case Type.Boots:
            {
                randStat1 = Stats.Stat.speed;
                randStat2 = Stats.Stat.damage;
                randValueOfStat1 = Random.Range(statsCreate.speedMin, statsCreate.speedMax);
                randValueOfStat2 = Random.Range(statsCreate.damageMin, statsCreate.damageMax);
                icon = itemIconsAndColors.bootsIcon;
                break;
            }
            case Type.Weapon:
            {
                randStat1 = Stats.Stat.attackSpeed;
                randStat2 = Stats.Stat.lifesteal;
                randValueOfStat1 = Random.Range(statsCreate.attackSpeedMin, statsCreate.attackSpeedMax);
                randValueOfStat2 = Random.Range(statsCreate.lifestealMin, statsCreate.lifestealMax);
                icon = itemIconsAndColors.weaponIcon;
                break;
            }
            case Type.Ring:
            {
                randStat1 = Stats.Stat.hpRegen;
                randStat2 = Stats.Stat.bonusExp;
                randValueOfStat1 = Random.Range(statsCreate.armorMin, statsCreate.armorMax);
                randValueOfStat2 = Random.Range(statsCreate.bonusExpMin, statsCreate.bonusExpMax);
                icon = itemIconsAndColors.ringIcon;
                break;
            }
        }

        stats.AddStat(randStat1, randValueOfStat1);
        stats.AddStat(randStat2, randValueOfStat2);
        stats.itemFirstStat = randStat1;
        stats.itemSecondStat = randStat2;

        Stats.Stat[] statMas = new Stats.Stat[2];
        float[] statV = new float[2];
        
        statMas[0] = randStat1;
        statMas[1] = randStat2;

        statV[0] = randValueOfStat1;
        statV[1] = randValueOfStat2;

        item.SetParam(type,quality,statMas,statV,backgroundColor,icon);
    }

    private Sprite CreateQuality()
    {
        Sprite backgroundColor = null;
        var value = Random.Range(0f, 100f);
        if (value < statsCreateBlue.orangeQualityChanse)
        {
            quality = Quality.Orange;
            statsCreate = statsCreateOrange;
            backgroundColor = itemIconsAndColors.orange;
        }

        if (value < statsCreateBlue.goldQualityChanse)
        {
            quality = Quality.Gold;
            statsCreate = statsCreateGold;
            backgroundColor = itemIconsAndColors.gold;
        }

        if (value < statsCreateBlue.purpleQualityChanse)
        {
            quality = Quality.Purple;
            statsCreate = statsCreatePurple;
            backgroundColor = itemIconsAndColors.purple;
        }

        if (value < statsCreateBlue.blueQualityChanse)
        {
            quality = Quality.Blue;
            statsCreate = statsCreateBlue;
            backgroundColor = itemIconsAndColors.blue;
        }

        if (value < statsCreateBlue.greenQualityChanse)
        {
            quality = Quality.Green;
            statsCreate = statsCreateGreen;
            backgroundColor = itemIconsAndColors.green;
        }

        if (quality.Equals(Quality.Grey))
        {
            statsCreate = statsCreateGrey;
            backgroundColor = itemIconsAndColors.grey;
        }

        return backgroundColor;
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