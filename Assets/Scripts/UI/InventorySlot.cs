using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public Items currentItem;

    public CreateItems.Type type;

    public void ShowItem()
    {
        currentItem.transform.position = transform.position;
    }
    
}
