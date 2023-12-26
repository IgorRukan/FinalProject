using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public BasePlayer player;

    private void Update()
    {
        Vector3 newPos = new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z-7f);
        transform.position = newPos;
    }
}
