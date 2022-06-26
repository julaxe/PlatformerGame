using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthSO _healthSo;
    [SerializeField] private RectTransform _currentHP;

    private void Awake()
    {
        _healthSo.takeDamage.AddListener(OnTakeDamage);
    }

    private void OnTakeDamage(float damage)
    {
        var percentage = (damage / _healthSo.maxHealth) * 100.0f;
        _currentHP.position -= new Vector3(percentage, 0.0f);
    }
}
