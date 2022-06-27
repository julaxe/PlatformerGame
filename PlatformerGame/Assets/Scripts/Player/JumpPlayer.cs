using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    public class JumpPlayer : MonoBehaviour
    {
        //serializable fields
        [SerializeField] private PlayerStats playerStats; 
        [SerializeField] private LayerMask layerMask;
        
        //components ref
        private Rigidbody2D _rigidbody2D;
        private CapsuleCollider2D _collider;
        
        //members
        private float _distToGround;
        
        //public members
        public UnityAction jumpEvent;
        public bool isGrounded;
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider = GetComponent<CapsuleCollider2D>();
            _distToGround = _collider.bounds.extents.y * 0.5f;
        }

        private void Update()
        {
            DrawLine();
            if (!isGrounded)
            {
                if(_rigidbody2D.velocity.y <= 0)
                    isGrounded = IsGrounded();
            }
        }

        public void OnJump(InputValue value)
        {
            if (isGrounded)
            {
                isGrounded = false;
                _rigidbody2D.velocity += new Vector2(0.0f, playerStats.jumpYVelocity);
                jumpEvent?.Invoke();
            }
        }

        void DrawLine()
        {
            Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.down * _distToGround), Color.cyan);
        }
        bool IsGrounded()
        {
            var start = transform.position + (Vector3.up * 0.1f);
            
            return Physics2D.Raycast(start, Vector3.down, _distToGround, layerMask);
        }
        
        
    }
}