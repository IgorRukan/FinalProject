using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : Singleton<StatManager>
{
    public Stats currentStats;

    private ObjectsManager objectsManager;

    private ItemSlotManager itemSlotManager;

    public Stats statsAddedPerLvl;

    private void Awake()
    {
        objectsManager = ObjectsManager.Instance;
        itemSlotManager = ItemSlotManager.Instance;
        currentStats = GetComponent<Stats>();
        SetPlayerStats(objectsManager.player.GetComponent<Stats>());
        SetItemStats();
    }

    public void SetItemStats()
    {
        foreach (var itemSlot in itemSlotManager.equippedSlots)
        {
            if (itemSlot.currentItem)
            {
                currentStats.AddAllStats(itemSlot.currentItem.GetComponent<Stats>(),true);
            }
        }
    }

    public void ChangeEquippedItem(InventorySlot slot,Items prevItem)
    {
        if (prevItem != null)
        {
            currentStats.AddAllStats(prevItem.GetComponent<Stats>(),false);
        }
        currentStats.AddAllStats(slot.currentItem.GetComponent<Stats>(),true);
    }

    public void DeleteItem(Items prevItem)
    {
        currentStats.AddAllStats(prevItem.GetComponent<Stats>(),false);
    }

    public Stats GetStatAddedPerLvl()
    {
        return statsAddedPerLvl;
    }

    public void SetPlayerStats(Stats statPerLevel)
    {
        currentStats.AddAllStats(statPerLevel,true);
    }
}
