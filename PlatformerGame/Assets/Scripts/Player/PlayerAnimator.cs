using System;
using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public enum PlayerAnimationStates
    {
        Idle,
        Combat,
        Running
    }
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private HealthSO playerHealth;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private JumpPlayer _jumpPlayer;
        [SerializeField] private MovePlayer _movePlayer;
        [SerializeField] private PlayerAnimationStates animationState;
        
        [Header("Animation Values")] 
        [SerializeField] private float knockBackDuration;
        
        
        private static readonly int GroundedHash = Animator.StringToHash("Grounded");
        private static readonly int JumpHash = Animator.StringToHash("Jump");
        private static readonly int AirSpeedYHash = Animator.StringToHash("AirSpeed");
        private static readonly int HurtHash = Animator.StringToHash("Hurt");
        private static readonly int AnimStateHash = Animator.StringToHash("AnimState");

        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _jumpPlayer = GetComponent<JumpPlayer>();
            _movePlayer = GetComponent<MovePlayer>();

            _jumpPlayer.jumpEvent += OnJumpEvent;
        }

        private void Start()
        {
            playerHealth.takeDamage.AddListener(TakeDamageAnimation);
        }

        private void Update()
        {
            _animator.SetBool(GroundedHash, _jumpPlayer.isGrounded);
            _animator.SetFloat(AirSpeedYHash, _rigidbody.velocity.y);
            UpdateState();
        }

        private void UpdateState()
        {
            switch (animationState)
            {
                case PlayerAnimationStates.Idle:
                    if (!_rigidbody.velocity.Equals(Vector2.zero))
                    {
                        SetAnimationState(PlayerAnimationStates.Running);
                    }
                    break;
                case PlayerAnimationStates.Running:
                    if (_rigidbody.velocity.Equals(Vector2.zero))
                    {
                        SetAnimationState(PlayerAnimationStates.Idle);
                    }
                    break;
                case PlayerAnimationStates.Combat:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void SetAnimationState(PlayerAnimationStates newState)
        {
            animationState = newState;
            _animator.SetInteger(AnimStateHash, (int)animationState);
        }

        private void OnJumpEvent()
        {
            _animator.SetTrigger(JumpHash);
        }

        private void TakeDamageAnimation(float damage)
        {
            _animator.SetTrigger(HurtHash);
            //Knock back
            StartCoroutine(KnockBackCoroutine(knockBackDuration));
        }

        IEnumerator KnockBackCoroutine(float knockBackSeconds)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x * -1.0f, _rigidbody.velocity.y);
            _movePlayer.StopInput();
            yield return new WaitForSeconds(knockBackSeconds);
            _movePlayer.ResumeInput();
        }
    }
}