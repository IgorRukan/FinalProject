using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] private Image experienceBarFilling;

    public TextMeshProUGUI expValueText;
    private Experience playerExp;
    public TextMeshProUGUI currentLvl;

    private void Awake()
    {
        experienceBarFilling = transform.Find("ExpBar").GetComponent<Image>();
        expValueText = GetComponentInChildren<TextMeshProUGUI>();
        
    }

    private void Start()
    {
        playerExp = ObjectsManager.Instance.player.GetComponent<Experience>();
        playerExp.ExpAdd += OnExpChanged;
    }

    private void OnExpChanged(int percentageExp)
    {
        experienceBarFilling.fillAmount = percentageExp;
        expValueText.text = playerExp.GetCurrentExp() +" / "+ playerExp.maxExp;
        currentLvl.text = playerExp.lvl.ToString();
    }

    private void LateUpdate()
    {
        expValueText.text = playerExp.GetCurrentExp()+" / "+ playerExp.maxExp;
        currentLvl.text = playerExp.lvl.ToString();
    }
}
