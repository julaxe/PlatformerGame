using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private VectorSO playerPosition;
        [SerializeField] private AttackValues attackValues;
        [SerializeField] private EnemyAttack enemyAttack;
        [SerializeField] private CapsuleCollider2D _capsuleCollider2D;

        //member values
        private bool _isAttacking = false;

        private void OnValidate()
        {
            enemyAttack = GetComponent<EnemyAttack>();
            _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            AttackIfInRange();
        }


        private void AttackIfInRange()
        {
            var distanceToPlayer = Vector2.Distance(transform.position, playerPosition.position);
            if (distanceToPlayer < attackValues.range)
            {
                if (!_isAttacking)
                {
                    StartCoroutine(AttackCoroutine(attackValues.cooldown));
                }
                else
                {
                    DrawLineOfAttack();
                }
            }
        }

        private void DrawLineOfAttack()
        {
            var center = _capsuleCollider2D.bounds.center;
            Debug.DrawLine(center, center + Vector3.left * attackValues.hitDistance, Color.cyan);
        }
        IEnumerator AttackCoroutine(float cd)
        {
            _isAttacking = true;
            enemyAttack.Attack();
            yield return new WaitForSeconds(cd);
            _isAttacking = false;
        }
    }
}