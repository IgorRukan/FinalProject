using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    public int exp;
    public int maxExp;

    public int lvl;
    
    private int levelUped
    
    {
        get
        {
            var lvlUpPoint=0;
            do
            {
                exp -= maxExp;
                lvlUpPoint++;
            } while (exp>maxExp);

            return lvlUpPoint;
        }
    }

    public event Action LvlUp;

    public void AddExp(int value)
    {
        exp += value;
        CheckIsLvlUp();
    }

    private void CheckIsLvlUp()
    {
        if (exp > maxExp)
        {
            LvlUp?.Invoke();
            exp -= maxExp;
            maxExp += (int)(maxExp * 0.05f);
            lvl += 1;
        }
    }
}