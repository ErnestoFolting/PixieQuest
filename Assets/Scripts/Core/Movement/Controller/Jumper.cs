using Core.Movement.Data;
using UnityEngine;

namespace Core.Movement.Controller
{
    public class Jumper
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly JumperData _jumperData;
        public Jumper(Rigidbody2D rigidBody, JumperData data)
        {
            _jumperData = data;
            _rigidbody = rigidBody;
        }
        public void Jump()
        {   
            if (IsGrounded())
            {
                _rigidbody.AddForce(Vector2.up * _jumperData.JumpForce );
            }
        }

        public void LongJump()
        {
            var velocity = _rigidbody.velocity;
            if (velocity.y > 0)
            {
                velocity = new Vector2(velocity.x, velocity.y * 0.5f);
                _rigidbody.velocity = velocity;
            }
        }

        public bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_jumperData.GroundCheck.position, 0.2f, _jumperData.GroundLayer);
        }
    }
}