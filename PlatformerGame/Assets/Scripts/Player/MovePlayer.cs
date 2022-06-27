using DefaultNamespace;
using UnityEngine;

namespace Player
{
    public class MovePlayer : MonoBehaviour
    {
        [SerializeField] private VectorSO playerPosition;
        [SerializeField] private PlayerStats _playerStats;
        private Rigidbody2D _rigidbody;
        private PlayerInputController _playerController;
        private bool _inputBlocked = false;
        
        private void Awake()
        {
            _playerController = GetComponent<PlayerInputController>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            UpdateVelocityIfThereIsInput();
            
            playerPosition.position = transform.position;
        }

        private void UpdateVelocityIfThereIsInput()
        {
            if (!_playerController.direction.Equals(Vector2.zero) && !_inputBlocked)
            {
                UpdateVelocity();
                UpdateFacingSide();
            }
        }

        private void UpdateVelocity()
        {
            var desiredVelocityX = _playerStats.maxSpeed * _playerController.direction.x;
            var desiredVelocity = new Vector2(desiredVelocityX, _rigidbody.velocity.y);
            _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, desiredVelocity, _playerStats.acceleration);
        }
        private void UpdateFacingSide()
        {
            transform.localScale = _rigidbody.velocity.x switch
            {
                > 0 => new Vector3(1.0f, transform.localScale.y, transform.localScale.z),
                < 0 => new Vector3(-1.0f, transform.localScale.y, transform.localScale.z),
                _ => transform.localScale
            };
        }

        public void StopInput()
        {
            _inputBlocked = true;
        }

        public void ResumeInput()
        {
            _inputBlocked = false;
        }

    }
}