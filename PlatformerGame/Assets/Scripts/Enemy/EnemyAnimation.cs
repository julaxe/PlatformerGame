using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyAttack _enemyAttack;
    private static readonly int HashAttack = Animator.StringToHash("Attack");

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
        _enemyAttack = GetComponent<EnemyAttack>();
    }
    private void Start()
    {
        _enemyAttack.OnAttack += AttackAnimation;
    }

    private void AttackAnimation()
    {
        _animator.SetTrigger(HashAttack);
    }
}
