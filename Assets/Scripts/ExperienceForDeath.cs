using TMPro;
using UnityEngine;

public class ExperienceForDeath : MonoBehaviour
{
    public int expForKill;

    public int moneyForKill;

    public TextMeshProUGUI moneyText;

    public void Start()
    {
        GetComponent<HealthSystem>().Death += EnemyDeath;
    }

    private void EnemyDeath(GameObject g)
    {
        Experience playerExp = ObjectsManager.Instance.player.GetComponent<Experience>();
        playerExp.AddExp(expForKill);
        
        ObjectsManager.Instance.player.GetComponent<PlayerResources>().
            AddOrTakeResourse(PlayerResources.resourses.money, moneyForKill, 1);

        ItemDrop itemDrop = GetComponent<ItemDrop>();
        itemDrop.DropItem(transform.position);
    }
}
