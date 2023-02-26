using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {
        public Animator Animator;
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

        private void Update()
        {
            if (IsGrounded())
            {
                Animator.SetBool("IsJumping",false);
            }
            else
            {
                Animator.SetBool("IsJumping",true);
            }
        }

        public void MoveHorizontally(float direction)
        {
            Animator.SetFloat("Speed", Mathf.Abs(_horizontalSpeed * direction));
            CheckIfChangeDirection(direction);
            Vector2 velocity = _rigidbody.velocity;
            velocity.x = direction * _horizontalSpeed;
            _rigidbody.velocity = velocity;
        }

        public void Jump()
        {   
            if (IsGrounded())
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce );
            }
        }

        public void LongJump()
        {
            if (_rigidbody.velocity.y > 0)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
            }
        }

        private bool IsGrounded()
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
