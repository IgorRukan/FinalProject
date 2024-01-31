using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Experience : MonoBehaviour
{
    public int exp;
    public int maxExp;
    public int lvl;
    
    // private int levelUped
    //
    // {
    //     get
    //     {
    //         var lvlUpPoint=0;
    //         do
    //         {
    //             exp -= maxExp;
    //             lvlUpPoint++;
    //         } while (exp>maxExp);
    //
    //         return lvlUpPoint;
    //     }
    // }

    public Experience()
    {
    }

    public event Action LvlUp;
    public event Action<int> ExpAdd;

    public void AddExp(int value)
    {
        exp += value;
        var expPercentage = exp / maxExp;
        ExpAdd.Invoke(expPercentage);
        CheckIsLvlUp();
    }

    public int GetCurrentExp()
    {
        return exp;
    }

    private void CheckIsLvlUp()
    {
        if (exp > maxExp)
        {
            exp -= maxExp;
            maxExp += (int)(maxExp * 0.05f);
            lvl += 1;
            LvlUp?.Invoke();
        }
    }

    public void SetParam(ExperienceSave playerExp)
    {
        exp = playerExp.exp;

        maxExp = playerExp.maxExp;

        lvl = playerExp.lvl;
    }
}