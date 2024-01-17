using UnityEngine;

public class ExperienceForDeath : MonoBehaviour
{
    public int expForKill;

    public Experience playerExp;

    public void Start()
    {
        GetComponent<HealthSystem>().Death += Exp;
    }

    private void Exp(GameObject g)
    {
        playerExp.AddExp(expForKill);
    }
}
