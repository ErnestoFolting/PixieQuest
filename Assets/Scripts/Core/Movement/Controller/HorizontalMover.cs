using Core.Movement.Data;
using UnityEngine;

namespace Core.Movement.Controller
{
    public class HorizontalMover
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;
        private readonly HorizontalMovementData _horizontalMovementData;

        private Vector2 _movement;
        public bool IsMoving => _movement.magnitude > 0;
        public HorizontalMover(Rigidbody2D rigidbody2D, HorizontalMovementData horizontalMovementData)
        {
            _rigidbody = rigidbody2D;
            _transform = _rigidbody.transform;
            _horizontalMovementData = horizontalMovementData;
        }
        public void MoveHorizontally(float direction)
        {
            _movement.x = direction;
            CheckIfChangeDirection(direction);
            Vector2 velocity = _rigidbody.velocity;
            velocity.x = direction * _horizontalMovementData.HorizontalSpeed;
            _rigidbody.velocity = velocity;
        }
        public void CheckIfChangeDirection(float direction)
        {
            if (_horizontalMovementData.IsFaceRight && direction < 0 || 
                !_horizontalMovementData.IsFaceRight && direction > 0)
            {
                FlipCharacter();
            }
        }

        private void FlipCharacter()
        {
            _transform.Rotate(0,180,0);
            _horizontalMovementData.IsFaceRight = !_horizontalMovementData.IsFaceRight;
        }
    }
}