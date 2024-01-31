using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : Singleton<ObjectsManager>
{
    public GameObject player;
    
    public Enemy enemyPrefab;
    
    public MineObjects treePrefab;

    private void Awake()
    {
        //player = Save.LoadPlayerInfoJSON<>("Save");
    }
}
