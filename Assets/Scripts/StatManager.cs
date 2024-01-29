using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : Singleton<StatManager>
{
    public Stats currentStats;

    private ObjectsManager objectsManager;

    private ItemSlotManager itemSlotManager;

    private void Awake()
    {
        objectsManager = ObjectsManager.Instance;
        itemSlotManager = ItemSlotManager.Instance;
        currentStats = GetComponent<Stats>();
        SetPlayerStats();
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

    private void SetPlayerStats()
    {
        var player = objectsManager.player;
        
        var playerStats = player.GetComponent<Stats>();
        
        currentStats.AddAllStats(playerStats,true);
    }
}
