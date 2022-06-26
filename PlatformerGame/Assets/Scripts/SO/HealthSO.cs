using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "HealthSO", menuName = "HealthSO", order = 0)]
public class HealthSO : ScriptableObject
{
    public float currentHealth;
    public float maxHealth;

    public UnityEvent<float> takeDamage;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void OnTakeDamage(float damage)
    {
        if (currentHealth == 0.0f) return;

        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        takeDamage?.Invoke(damage);
    }
    
    
}