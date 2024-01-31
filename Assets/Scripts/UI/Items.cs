using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Items : MonoBehaviour, IPointerEnterHandler
{
    public Action<Items> OnClicked;

    public CreateItems.Type type;

    public CreateItems.Quality quality;

    public CreateItems createItems;

    private Stats stats;

    public InventorySlot currentSlot;

    public Stats.Stat[] stat;
    public float[] statValue;

    public GameObject equipMenu;

    public Sprite backgroundColor = null;
    public Sprite icon = null;
    
    

    private void Start()
    {
        stats = GetComponent<Stats>();
        createItems = FindObjectOfType<CreateItems>();
        createItems.SetStats(stats, this);
        equipMenu = GameObject.FindGameObjectWithTag("EquipItemMenu");
    }

    public void SetParam(CreateItems.Type t, CreateItems.Quality q, Stats.Stat[] st, float[] statV,
        Sprite backgroundColor, Sprite icon)
    {
        type = t;
        quality = q;
        stat = st;
        statValue = statV;
        this.backgroundColor = backgroundColor;
        this.icon = icon;
        transform.Find("Background").GetComponent<Image>().sprite = backgroundColor;
        transform.Find("ItemIcon").GetComponent<Image>().sprite = icon;
        
        
    }

    public void ItemSetCurrentSlot(InventorySlot curSlot)
    {
        currentSlot = curSlot;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnClicked(this);
    }
}