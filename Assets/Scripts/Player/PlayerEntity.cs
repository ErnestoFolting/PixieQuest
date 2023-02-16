using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {
        [Header("HorizontalMovement")]
        [SerializeField] private float _horizontalSpeed;
        [SerializeField] private bool _isFaceRight;

        [Header("Jump")] 
        [SerializeField] private float _jumpForce;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask  _groundLayer;
        
        private Rigidbody2D _rigidbody;
        private bool _isJumping;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void MoveHorizontally(float direction)
        {
            CheckIfChangeDirection(direction);
            Vector2 velocity = _rigidbody.velocity;
            velocity.x = direction * _horizontalSpeed;
            _rigidbody.velocity = velocity;
        }

        public void Jump()
        {
            if (isGrounded())
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce );
            }
        }

        private bool isGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
        }
        
        private void CheckIfChangeDirection(float direction)
        {
            if (_isFaceRight && direction < 0 || 
                !_isFaceRight && direction > 0)
            {
                FlipCharacter();
            }
        }

        private void FlipCharacter()
        {
            transform.Rotate(0,180,0);
            _isFaceRight = !_isFaceRight;
        }
    }
}
