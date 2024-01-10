using System.Collections;
using UnityEngine;

public class TreeMine : MonoBehaviour
{
    private bool isMinening;
    private HealthSystem hs;
    private BasePlayer player;
    public float reward;
    private DamageableObject mineObject;

    private void Start()
    {
        mineObject = GetComponentInParent<DamageableObject>();
        hs = mineObject.GetHealthSystem();
    }

    private void Mine()
    {
        isMinening = true;
        player.GetComponent<Stats>().isMinening = true;
        StartCoroutine(MineTree());
    }

    private void StopMine()
    {
        isMinening = false;
        player.GetComponent<Stats>().isMinening = false;
    }

    IEnumerator MineTree()
    {
        hs.Death += OnDeath;
        while (true)
        {
            if (!isMinening)
            {
                hs.Death -= OnDeath;
                yield break;
            }

            hs.GetDamage(player.GetComponent<Stats>().axeDamage);
            yield return new WaitForSeconds(player.GetComponent<Stats>().axeSpeed);
        }
    }

    private void OnDeath(GameObject go)
    {
        player.GetComponent<Stats>().AddStat("wood", reward);
        hs.Death -= OnDeath;
        isMinening = false;
        player.GetComponent<Stats>().isMinening = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<BasePlayer>();
        if (!player.GetComponent<Stats>().isMinening)
        {
            Mine();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopMine();
    }
}