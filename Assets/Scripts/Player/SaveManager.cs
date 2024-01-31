using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private GameObject player;

    private string filenamePlayerStats = "DataPlayerStats";
    private string filenamePlayerExp = "DataPlayerExp";

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
    }

    public void LoadData()
    {
        StatsSave statInfo = Save.LoadPlayerInfoJSON<StatsSave>(filenamePlayerStats);
        ExperienceSave expInfo = Save.LoadPlayerInfoJSON<ExperienceSave>(filenamePlayerExp);
        player.GetComponent<Stats>().SetParam(statInfo);
        player.GetComponent<Experience>().SetParam(expInfo);
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

    
}