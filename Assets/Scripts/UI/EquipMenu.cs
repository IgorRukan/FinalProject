using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipMenu : MonoBehaviour
{
    public Items item;

    public ItemSlotManager itemSlotManager;

    public TextMeshProUGUI stat1Text;
    public TextMeshProUGUI stat2Text;
    public TextMeshProUGUI itemName;
    public Image icon;
    public Image background;

    private void Start()
    {
        itemSlotManager = ItemSlotManager.Instance;
    }

    public void SetItem(Items item)
    {
        this.item = item;
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

    public void DeleteItem()
    {
        foreach (var slot in ItemSlotManager.Instance.equippedSlots)
        {
            if (item.Equals(slot.currentItem))
            {
                
                StatManager.Instance.DeleteItem(item);
            }
        }
        item.currentSlot.RemoveItem();
        Destroy(item.gameObject);
    }

    public void SetUIElements(Items curItem)
    {
        itemName.text = curItem.type.ToString();
        var itemStats = curItem.GetComponent<Stats>();
        stat1Text.text = itemStats.itemFirstStat+" : "+Math.Round(itemStats.StatValue(itemStats.itemFirstStat),1);
        stat2Text.text = itemStats.itemSecondStat+" : "+Math.Round(itemStats.StatValue(itemStats.itemSecondStat),1);
        icon.sprite = curItem.transform.Find("ItemIcon").GetComponent<Image>().sprite;
        background.sprite = curItem.transform.Find("Background").GetComponent<Image>().sprite;
    }
}
