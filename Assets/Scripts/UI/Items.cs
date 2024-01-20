using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Items : MonoBehaviour
{
    public enum Type
    {
        Head,
        Armor,
        Trousers,
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

    public Type type;

    public Quality quality;
    
    private Stats stats;

    public Stats.Stat[] stat;
    public float[] statValue;

    private void Start()
    {
        stats = GetComponent<Stats>();
        SetStats();
    }

    private void SetStats()
    {
        type = GetRandomEnumValue(Type.Head,Type.Weapon);
        switch (type)
        {
            case Type.Head:
            {
                var randDmg = Random.Range(25f, 50f);
                stats.AddStat(Stats.Stat.damage,randDmg);
                break;
            }
            case Type.Armor:
            {
                break;
            }
            case Type.Boots:
            {
                break;
            }
            case Type.Trousers:
            {
                break;
            }
            case Type.Weapon:
            {
                break;
            }
            case Type.Ring:
            {
                break;
            }
        }
    }
    
    private T GetRandomEnumValue<T>(T minValue, T maxValue)
    {
        Array values = Enum.GetValues(typeof(T));
        int minIndex = Array.IndexOf(values, minValue);
        int maxIndex = Array.IndexOf(values, maxValue);
        int randomIndex = UnityEngine.Random.Range(minIndex, maxIndex + 1);
        return (T)values.GetValue(randomIndex);
    }
}
