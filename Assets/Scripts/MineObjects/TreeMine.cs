using System;
using System.Collections;
using UnityEngine;

public class TreeMine : MonoBehaviour
{
    private bool isMinening;
    private HealthSystem hs;
    private BasePlayer player;
    private int reward;
    private DamageableObject mineObject;
    private Transform LookPoint;
    private bool stopAnim = false;

    private void Start()
    {
        mineObject = GetComponentInParent<DamageableObject>();

        hs = mineObject.GetHealthSystem();
        reward = mineObject.GetReward();
        LookPoint = transform.Find("LookPoint");
    }

    private void Mine()
    {
        isMinening = true;
        player.GetComponent<Stats>().isMinening = true;
        stopAnim = false;
        StartCoroutine(MineTree());
    }

    private void StopMine()
    {
        stopAnim = true;
        isMinening = false;
        player.GetComponent<Stats>().isMinening = false;
        player.GetComponent<Animations>().StopCurrentAnimation();
        player.GetComponent<Animations>().MineTreeAnimation(false);
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

            if (player.GetComponent<Stats>().isFight)
            {
                yield break;
            }

            if (!stopAnim)
            {
                player.GetComponent<Animations>().MineTreeAnimation(true);
                player.transform.LookAt(LookPoint);
                yield return new WaitForSeconds(player.GetComponent<Stats>().axeSpeed);
                hs.GetMineObjectDamage(player.GetComponent<Stats>().axeDamage);
                player.GetComponent<Animations>().MineTreeAnimation(false);
            }

        }
    }

    private void OnDeath(GameObject go)
    {
        player.GetComponent<PlayerResources>().AddOrTakeResourse(PlayerResources.resourses.wood, reward, 1);
        hs.Death -= OnDeath;
        isMinening = false;
        player.GetComponent<Stats>().isMinening = false;
    }

    private void OnTriggerStay(Collider other)
    {
        player = other.GetComponent<BasePlayer>();
        if (!player)
        {
            return;
        }

        if (player.GetComponent<JoystickMovement>().IsStay().Equals(true)&&!isMinening)
        {
            if (!player.GetComponent<Stats>().isMinening)
            {
                player.transform.LookAt(LookPoint);
                Mine();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopMine();
    }
}