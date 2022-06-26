using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class MovePlayer : MonoBehaviour
    {
        [SerializeField] private VectorSO playerPosition;
        [SerializeField] private float speed;
        private Rigidbody2D _rigidbody;
        private PlayerInputController _playerController;
        
        private void Awake()
        {
            _playerController = GetComponent<PlayerInputController>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!_playerController.direction.Equals(Vector2.zero))
            {
                _rigidbody.velocity = new Vector2(_playerController.direction.x * speed, _rigidbody.velocity.y);
                transform.localScale = _rigidbody.velocity.x switch
                {
                    > 0 => new Vector3(1.0f, transform.localScale.y, transform.localScale.z),
                    < 0 => new Vector3(-1.0f, transform.localScale.y, transform.localScale.z),
                    _ => transform.localScale
                };
            }

            playerPosition.position = transform.position;
        }
        
    }
}