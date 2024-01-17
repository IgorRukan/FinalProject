using System.Collections;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public float damageAmount;
    [SerializeField] private float damagePeriod;
    [SerializeField] private LayerMask ignoredLayers;

    private HealthSystem damagable;

    public void SetDamage(float damage)
    {
        damageAmount = damage;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if ((ignoredLayers.value & (1<<other.gameObject.layer)) == 0)
        {
            if (other.GetComponent<HealthSystem>())
            {
                damagable = other.GetComponent<HealthSystem>();

                damagable.GetDamage(damageAmount);
                
                damagable.LifeSteal();

                if (damagePeriod > 0)
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
            yield return new WaitForSeconds(damagePeriod);
            damagable.GetDamage(damageAmount);
        }
    }

    private void OnDestroy()
    { 
        //damagable.Death -= OnDamagableDeath;
        StopAllCoroutines();
    }
}
