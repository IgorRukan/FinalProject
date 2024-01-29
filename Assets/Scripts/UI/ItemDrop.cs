using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemDrop : MonoBehaviour
{
    public Items item;

    public Transform itemCanvas;

    public int dropChanse;

    public ItemRecieveMes itemReceivedWindow;

    private bool droped = false;

    public ItemSlotManager itemSlotManager;

    private void Start()
    {
        itemSlotManager = ItemSlotManager.Instance;
        itemReceivedWindow = itemSlotManager.itemRecieveMessage;
        item = itemSlotManager.itemPrefab;
    }

    public void DropItem(Vector3 pos)
    {
        var value = Random.Range(0f, 100f);
        if (value <= dropChanse)
        {
            var dropItem = Instantiate(item);

            dropItem.transform.SetParent(itemCanvas);
            
            itemReceivedWindow.gameObject.SetActive(true);

            itemSlotManager.AddItem(dropItem);
            
            itemReceivedWindow.MessageLive();
        }
    }
}