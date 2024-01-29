using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMenu : MonoBehaviour
{
    public Items item;

    public ItemSlotManager itemSlotManager;

    private void Start()
    {
        itemSlotManager = FindObjectOfType<ItemSlotManager>();
    }

    public void SetItem(Items item)
    {
        this.item = item;
    }

    public void ShowInfo()
    {
        
    }

    public void EquipItem()
    {
        foreach (var slot in itemSlotManager.equippedSlots)
        {
            if (slot.type.Equals(item.type))
            {
                var prevSlot = item.currentSlot;
                var prevItem = item;
                if (!slot.currentItem)
                {
                    slot.currentItem = item;
                    slot.currentItem.transform.position = slot.transform.position;
                    slot.currentItem.currentSlot = slot;
                    prevSlot.currentItem = null;
                    prevItem = null;
                }
                else
                {
                    (item, slot.currentItem) = (slot.currentItem, item);
                    slot.currentItem.transform.position = slot.transform.position;
                    slot.currentItem.currentSlot = slot;

                    item.transform.position = prevSlot.transform.position;
                    item.currentSlot = prevSlot;
                    prevItem = item;
                }
                StatManager.Instance.ChangeEquippedItem(slot,prevItem);
            }
        }
    }
}
