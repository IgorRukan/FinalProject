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
        healthValueText = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    private void OnHealthChanged(float percentageHealth)
    {
        healthBarFilling.fillAmount = percentageHealth;
        healthValueText.text = healthSystem.GetCurrentHealth().ToString();
    }

    private void LateUpdate()
    {
        healthValueText.text = healthSystem.GetCurrentHealth().ToString();
        transform.LookAt(new Vector3(transform.position.x,camera.transform.position.y,camera.transform.position.z));
        transform.Rotate(0,180,0);
    }
}
