using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Items : MonoBehaviour,IPointerEnterHandler
{

    public CreateItems.Type type;

    public CreateItems.Quality quality;

    public CreateItems createItems;
    
    private Stats stats;

    public InventorySlot currentSlot;

    public Stats.Stat[] stat;
    public float[] statValue;

    public GameObject equipMenu;

    private void Start()
    {
        stats = GetComponent<Stats>();
        createItems = FindObjectOfType<CreateItems>();
        createItems.SetStats(stats,this);
        equipMenu = GameObject.FindGameObjectWithTag("EquipItemMenu");
    }

    public void SetParam(CreateItems.Type t, CreateItems.Quality q, Stats.Stat[] st, float[] statV)
    {
        type = t;
        quality = q;
        stat = st;
        statValue = statV;
    }

    public void ItemSetCurrentSlot(InventorySlot curSlot)
    {
        currentSlot = curSlot;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        equipMenu.SetActive(true);
        equipMenu.GetComponent<EquipMenu>().SetItem(this);
    }
}
