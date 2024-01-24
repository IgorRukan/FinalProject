using UnityEngine;

public class ExperienceForDeath : MonoBehaviour
{
    public int expForKill;

    private Experience playerExp;

    public void Start()
    {
        GetComponent<HealthSystem>().Death += Exp;
    }

    private void Exp(GameObject g)
    {
        playerExp = GetComponent<PerceptionComponent>().GetTarget().GetComponent<Experience>();
        playerExp.AddExp(expForKill);

        ItemDrop itemDrop = GetComponent<ItemDrop>();
        itemDrop.DropItem(transform.position);
        
        
        
    }
}
