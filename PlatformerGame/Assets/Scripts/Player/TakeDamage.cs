using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class TakeDamage : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private HealthSO playerHealth;
        
        public void OnFire(InputValue value)
        {
            if (playerHealth.currentHealth == 0) return;
            
            playerHealth.currentHealth -= damage;
            if (playerHealth.currentHealth < 0)
            {
                playerHealth.currentHealth = 0;
            } 
        }
    }
}