using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthSO", menuName = "HealthSO", order = 0)]
public class HealthSO : ScriptableObject
{
    public float currentHealth;
    public float maxHealth;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }
}