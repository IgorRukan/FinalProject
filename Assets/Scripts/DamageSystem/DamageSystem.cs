using System.Collections;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] private float DamageAmmount;
    [SerializeField] private float DamagePeriod;
    [SerializeField] private LayerMask IgnoredLayers;

    private HealthSystem damagable;

    private void OnTriggerEnter(Collider other)
    {
        if ((IgnoredLayers.value & (1<<other.gameObject.layer)) == 0)
        {
            if (other.GetComponent<HealthSystem>())
            {
                damagable = other.GetComponent<HealthSystem>();

                damagable.GetDamage(DamageAmmount);

                if (DamagePeriod > 0)
                {
                    damagable.Death += OnDamagableDeath;
                    StartCoroutine(TakeDamage());
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (damagable)
        {
            damagable.Death -= OnDamagableDeath;
        }
        StopAllCoroutines();
    }

    private void OnDamagableDeath(GameObject gameObject)
    {
        damagable.Death -= OnDamagableDeath;
        StopAllCoroutines();
    }

    private IEnumerator TakeDamage()
    {
        while (true)
        {
            yield return new WaitForSeconds(DamagePeriod);
            damagable.GetDamage(DamageAmmount);
        }
    }

    private void OnDestroy()
    { 
        //damagable.Death -= OnDamagableDeath;
        StopAllCoroutines();
    }
}
