using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRecieveMes : MonoBehaviour
{
    public float waitTime;

    public void MessageLive()
    {
        StartCoroutine("Live");
    }
    
    private IEnumerator Live()
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
}
