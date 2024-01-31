using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarFilling;

    public HealthSystem healthSystem;

    private Camera camera;

    public TextMeshProUGUI healthValueText;

    private void Awake()
    {
        camera = Camera.main;
        healthBarFilling = transform.Find("HealthBar").GetComponent<Image>();
        healthSystem.ChangeHealth += OnHealthChanged;
        healthSystem.Death += OnDeath;
        healthValueText = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    private void OnHealthChanged(float percentageHealth)
    {
        healthBarFilling.fillAmount = percentageHealth;
        healthValueText.text = Math.Round(healthSystem.GetCurrentHealth(),0).ToString();
    }

    private void OnDeath(GameObject a)
    {
        healthBarFilling.fillAmount = healthSystem.maxHealth;
        Debug.Log("EnemyDead");
        healthValueText.text = Math.Round(healthSystem.GetCurrentHealth(),0).ToString();
    }

    private void LateUpdate()
    {
        healthValueText.text = Math.Round(healthSystem.GetCurrentHealth(),0).ToString();
        transform.LookAt(new Vector3(transform.position.x,camera.transform.position.y,camera.transform.position.z));
        transform.Rotate(0,180,0);
    }
}
