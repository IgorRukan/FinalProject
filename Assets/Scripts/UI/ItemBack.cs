using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBack : MonoBehaviour
{
    public bool change;
    public bool nol = false;
    public Color back;
    public Color back2;

    private void Update()
    {
        if (!nol)
        {
            return;
        }
        if (change)
        {
            Change(back);
        }
        else
        {
            Change(back2);
        }
    }

    private void Change(Color color)
    {
        GetComponent<Image>().color = color;
    }
}
