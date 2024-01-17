using System;
using System.Collections;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float price;
    public float currentAmountOfResource;
    public float maxAmountOfResource;
    public float collectSpeed;

    public float mineUpgradeCoef;
    public float priceUpgradeCoef;
    public float amountUpgradeCoef;

    public GameObject button;

    private BasePlayer player;

    private void Start()
    {
        StartCoroutine(MineRes());
    }

    public void Mine()
    {
        currentAmountOfResource += maxAmountOfResource * mineUpgradeCoef;
        currentAmountOfResource = Mathf.Clamp(currentAmountOfResource, 0, maxAmountOfResource);
    }

    public void Collect()
    {
        currentAmountOfResource -= collectSpeed;
        currentAmountOfResource = Mathf.Clamp(currentAmountOfResource, 0, maxAmountOfResource);
    }

    public void Upgrade()
    {
        player.GetComponent<Stats>().damage -= price;
        price += price * priceUpgradeCoef;
        maxAmountOfResource += maxAmountOfResource * amountUpgradeCoef;
    }

    IEnumerator MineRes()
    {
        while (true)
        {
            Mine();
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        button.gameObject.SetActive(true);
        player = other.GetComponent<BasePlayer>();
    }

    private void OnTriggerExit(Collider other)
    {
        button.gameObject.SetActive(false);
        player = null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<BasePlayer>())
        {
            Collect();
        }
    }
}