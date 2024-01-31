using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public int money;
    public int wood;
    public int metal;
    public int gems;

    public TextMeshProUGUI moneyTxt;
    public TextMeshProUGUI woodTxt;
    public TextMeshProUGUI metalTxt;
    public TextMeshProUGUI gemsTxt;
    
    public enum resourses{
        money,
        wood,
        metal,
        gems
    }

    private void Start()
    {
        var uiManager = UIElementsManager.Instance;
        moneyTxt = uiManager.moneyText;
        woodTxt = uiManager.woodText;
        metalTxt = uiManager.metalText;
        gemsTxt = uiManager.gemsText;
    }

    public void AddOrTakeResourse(resourses resourceName, int value, int sign)
    {
        var field = GetType().GetField(resourceName.ToString());

        if (field != null && field.FieldType == typeof(int))
        {
            var currentValue = (int)field.GetValue(this);

            int newValue;
            
            if (sign > 0)
            {
                newValue = currentValue + value;
                Debug.Log("Added");
            }
            else
            {
                newValue = currentValue - value;
            }

            field.SetValue(this, newValue);
        }
        else
        {
            Debug.LogError("Invalid stat name or type: " + resourceName);
        }
    }

    public void SetParam(PlayerResSave newValue)
    {
        money = newValue.money;
        wood = newValue.wood;
        metal = newValue.metal;
        gems = newValue.gems;
    }

    public void ShowRes()
    {
        moneyTxt.text = money.ToString();
        woodTxt.text = wood.ToString();
        metalTxt.text = metal.ToString();
        gemsTxt.text = gems.ToString();
    }

    private void LateUpdate()
    {
        ShowRes();
    }
}