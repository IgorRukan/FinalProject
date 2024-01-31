using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotManager : Singleton<ItemSlotManager>
{
    public List<Items> items;

    public InventorySlot[] inventorySlots;
    public InventorySlot[] equippedSlots;

    public EquipMenu equipMenu;

    public ItemRecieveMes itemRecieveMessage;
    
    public Items itemPrefab;
    
    public void AddItem(Items item)
    {
        items.Add(item);
        foreach (var slot in inventorySlots)
        {
            if (!slot.currentItem && !item.currentSlot)
            {
                slot.currentItem = item;
                slot.ShowItem();
                item.ItemSetCurrentSlot(slot);
                item.OnClicked += OnItemClicked;
                break;
            }
        }
    }

    public void OnItemClicked(Items clickedItem)
    {
        equipMenu.gameObject.SetActive(true);
        equipMenu.SetItem(clickedItem);
        equipMenu.SetUIElements(clickedItem);
    }
    
    public void RemoveItem(Items item)
    {
        items.Remove(item);
        item.OnClicked -= OnItemClicked;
    }
    
}
