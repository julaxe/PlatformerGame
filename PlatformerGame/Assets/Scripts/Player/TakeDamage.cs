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
            playerHealth.OnTakeDamage(damage);
        }
    }
}