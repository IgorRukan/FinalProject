using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private GameObject player;

    private string filenamePlayerStats = "DataPlayerStats";
    private string filenamePlayerExp = "DataPlayerExp";
    private string filenamePlayerItems = "DataPlayerItems";
    private string filenamePlayerRes = "DataPlayerRes";

    public float timePerSave;

    private void Awake()
    {
        player = ObjectsManager.Instance.player;
        LoadData();
        StartCoroutine(SaveTime());
    }

    IEnumerator SaveTime()
    {
        while (true)
        {
            SaveData();
            yield return new WaitForSeconds(timePerSave);
        }
    }

    public void SaveData()
    {
        Save.SavePlayerInfoJSON(filenamePlayerStats, GetPlayerStatInfo());
        Save.SavePlayerInfoJSON(filenamePlayerExp, GetPlayerExperienceInfo());
        Save.SavePlayerInfoJSONlist(filenamePlayerItems, GetPlayerItemsInfo()); 
        Save.SavePlayerInfoJSON(filenamePlayerRes, GetPlayerResInfo()); 
    }

    public void LoadData()
    {
        StatsSave statInfo = Save.LoadPlayerInfoJSON<StatsSave>(filenamePlayerStats);
        ExperienceSave expInfo = Save.LoadPlayerInfoJSON<ExperienceSave>(filenamePlayerExp);
        PlayerResSave resInfo = Save.LoadPlayerInfoJSON<PlayerResSave>(filenamePlayerRes);
        if (statInfo != null)
        {
            player.GetComponent<Stats>().SetParam(statInfo);
        }

        if (expInfo != null)
        {
            player.GetComponent<Experience>().SetParam(expInfo);
        }
        if (resInfo != null)
        {
            player.GetComponent<PlayerResources>().SetParam(resInfo);
        }

        // List<ItemsSave> itemInfo = Save.LoadPlayerInfoJSONList<ItemsSave>(filenamePlayerItems);
        // if (itemInfo != null)
        // {
        //     var itemSlotManager = ItemSlotManager.Instance;
        //     Items [] itemMas = new Items[itemInfo.Count];
        //     int i = 0;
        //     foreach (var item in itemInfo)
        //     {
        //         itemMas[i].SetParam(item.type, item.quality, item.stat, item.statValue,
        //             item.backgroundColor, item.icon);
        //         itemSlotManager.AddItem(itemMas[i]);
        //         i++;
        //     }
        // }    не рабоатет
    }

    StatsSave GetPlayerStatInfo()
    {
        StatsSave info = new StatsSave();

        Stats playerStats = player.GetComponent<Stats>();

        info.damage = playerStats.damage;
        info.armor = playerStats.armor;
        info.lifesteal = playerStats.lifesteal;
        info.speed = playerStats.speed;
        info.attackRange = playerStats.attackRange;
        info.bigAttackRange = playerStats.bigAttackRange;
        info.attackSpeed = playerStats.attackSpeed;
        info.maxHealth = playerStats.maxHealth;
        info.hpRegen = playerStats.hpRegen;
        info.currentHp = playerStats.currentHp;
        info.crit = playerStats.crit;
        info.critChance = playerStats.critChance;
        info.bonusExp = playerStats.bonusExp;
        info.axeDamage = playerStats.axeDamage;
        info.axeSpeed = playerStats.axeSpeed;
        info.pickaxeDamage = playerStats.pickaxeDamage;
        info.pickaxeSpeed = playerStats.pickaxeSpeed;
        info.isMinening = false;
        info.itemFirstStat = Stats.Stat.armor;
        info.itemSecondStat = Stats.Stat.armor;

        return info;
    }

    ExperienceSave GetPlayerExperienceInfo()
    {
        ExperienceSave info = new ExperienceSave();


        Experience playerExp = player.GetComponent<Experience>();

        info.exp = playerExp.exp;

        info.maxExp = playerExp.maxExp;

        info.lvl = playerExp.lvl;

        return info;
    }

    List<ItemsSave> GetPlayerItemsInfo()
    {
        List<ItemsSave> info = new List<ItemsSave>();
        ItemsSave infoItem = new ItemsSave();

        List<Items> playerItemsMas = ItemSlotManager.Instance.items;

        foreach (var playerItems in playerItemsMas)
        {
            infoItem.type = playerItems.type;

            infoItem.quality = playerItems.quality;

            infoItem.currentSlot = playerItems.currentSlot;

            infoItem.stat = playerItems.stat;

            infoItem.statValue = playerItems.statValue;

            infoItem.backgroundColor = playerItems.backgroundColor;

            infoItem.icon = playerItems.icon;
            
            info.Add(infoItem);
        }
        return info;
    }
    
    PlayerResSave GetPlayerResInfo()
    {
        PlayerResSave info = new PlayerResSave();
        
        PlayerResources playerRes = player.GetComponent<PlayerResources>();

        info.money = playerRes.money;

        info.wood = playerRes.wood;

        info.metal = playerRes.metal;
        info.gems = playerRes.gems;

        return info;
    }
}