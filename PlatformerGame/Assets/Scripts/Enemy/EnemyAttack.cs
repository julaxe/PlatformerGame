using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : MonoBehaviour
{
    public UnityAction OnAttack;

    public void Attack()
    {
        OnAttack?.Invoke();
    }
}
