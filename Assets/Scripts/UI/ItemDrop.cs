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
        itemSlotManager = FindObjectOfType<ItemSlotManager>();
    }

    public void DropItem(Vector3 pos)
    {
        var value = Random.Range(0f, 100f);
        if (value <= dropChanse)
        {
            var dropItem = Instantiate(item);
            //dropItem.transform.position = pos;
            dropItem.transform.Rotate(0f, 180f, 0f);
            // dropItem.transform.position = Vector3.Lerp(dropItem.transform.position,
            //     new Vector3(dropItem.transform.position.x-3f, dropItem.transform.position.y+10f,
            //         dropItem.transform.position.z)
            //     , 2f);

            dropItem.transform.SetParent(itemCanvas);
            
            itemReceivedWindow.gameObject.SetActive(true);

            itemSlotManager.AddItem(dropItem);
            
            itemReceivedWindow.MessageLive();
        }
    }
}