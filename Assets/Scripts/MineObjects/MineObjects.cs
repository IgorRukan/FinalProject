using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineObjects : DamageableObject
{
    public HealthSystem hs;
    public int reward;

    private void Start()
    {
        hs = GetComponent<HealthSystem>();
    }

    public override HealthSystem GetHealthSystem()
    {
        return hs;
    }
    
    public override int GetReward()
    {
        return reward;
    }
}
