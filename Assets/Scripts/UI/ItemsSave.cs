using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemsSave 
{
    public CreateItems.Type type;
    public CreateItems.Quality quality;
    
    public Stats stats;

    public InventorySlot currentSlot;

    public Stats.Stat[] stat;
    public float[] statValue;
    
    public Sprite backgroundColor;
    public Sprite icon;

}
