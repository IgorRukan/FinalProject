using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public int money;
    public int wood;
    public int stone;
    public int gems;

    public TextMeshProUGUI moneyTxt;
    public TextMeshProUGUI woodTxt;
    public TextMeshProUGUI stoneTxt;
    public TextMeshProUGUI gemsTxt;
    
    public enum resourses{
        money,
        wood,
        stone,
        gems
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

    public void ShowRes()
    {
        moneyTxt.text = money.ToString();
        woodTxt.text = wood.ToString();
        stoneTxt.text = stone.ToString();
        gemsTxt.text = gems.ToString();
    }

    private void LateUpdate()
    {
        ShowRes();
    }
}