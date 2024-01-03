using System;
using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float AutoHealPeriod = -1;
    [SerializeField] private float AutoHealValue;

    private float time;

    private float currentHealthPercentage;

    public event Action <GameObject> Death;

    public event Action<float> ChangeHealth; 

    private void Start()
    {
        Init();
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

    public void AddHealth(float value)
    {
        currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        ChangeHealthIv();
    }

    public void GetDamage(float value)
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

    private void Update()
    {
        AutoHeal(AutoHealPeriod, AutoHealValue);
    }
}
