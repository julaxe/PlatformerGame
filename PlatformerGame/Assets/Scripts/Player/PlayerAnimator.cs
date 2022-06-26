using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private JumpPlayer _jumpPlayer;
        private static readonly int GroundedHash = Animator.StringToHash("Grounded");
        private static readonly int JumpHash = Animator.StringToHash("Jump");
        private static readonly int AirSpeedYHash = Animator.StringToHash("AirSpeedY");
        private static readonly int RunningHash = Animator.StringToHash("Running");

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _jumpPlayer = GetComponent<JumpPlayer>();
            
            
            _jumpPlayer.jumpEvent += OnJumpEvent;
        }

        private void Update()
        {
            _animator.SetBool(GroundedHash, _jumpPlayer.isGrounded);
            _animator.SetFloat(AirSpeedYHash, _rigidbody.velocity.y);
            _animator.SetBool(RunningHash, _rigidbody.velocity.x != 0 ? true : false);
        }

        private void OnJumpEvent()
        {
            _animator.SetTrigger(JumpHash);
        }
    }
}