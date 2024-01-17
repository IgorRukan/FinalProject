using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float AutoHealPeriod = -1;
    [SerializeField] private float AutoHealValue;

    private float time;

    private float currentHealthPercentage;

    public event Action<GameObject> Death;

    public event Action<float> ChangeHealth;

    private Stats stats;
    private void Start()
    {
        Init();
        stats = GetComponent<Stats>();
    }

    public void Init()
    {
        currentHealth = maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetAutoHealPeriod(float period)
    {
        AutoHealPeriod = period;
    }

    public void SetAutoHealValue(float value)
    {
        AutoHealValue = value;
    }

    public void FullRestore()
    {
        currentHealth = maxHealth;
    }

    public void AddHealth(float value)
    {
        currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        ChangeHealthIv();
    }

    public void GetDamage(float value)
    {
        var crit = Random.Range(0, 100);
        var critDamage = 0f;
        if (stats.critChance >= crit)
        {
            critDamage = stats.crit;
        }
        currentHealth -= value + value*(critDamage/100f) - stats.armor * value;
        CheckIsDead();
        ChangeHealthIv();
    }

    public void GetMineObjectDamage(float value)
    {
        currentHealth -= value;
        CheckIsDead();
        ChangeHealthIv();
    }

    private void ChangeHealthIv()
    {
        currentHealthPercentage = currentHealth / maxHealth;
        ChangeHealth?.Invoke(currentHealthPercentage);
    }

    public void OnRevival()
    {
        Init();
    }

    private void CheckIsDead()
    {
        if (currentHealth <= 0)
        {
            Death?.Invoke(gameObject);
            currentHealth = 0;
            Debug.Log("Death");
        }
    }

    private void AutoHeal(float period, float value)
    {
        if (period <= 0)
            return;

        if (currentHealth >= maxHealth)
            return;

        time += Time.deltaTime;
        if (time > period)
        {
            AddHealth(value);
            time -= period;
        }
    }

    public void LifeSteal()
    {
        currentHealth += stats.lifesteal * stats.damage;
    }

    private void Update()
    {
        AutoHeal(AutoHealPeriod, AutoHealValue);
    }
}