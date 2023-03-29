using Core.Animation;
using Core.Movement.Controller;
using Core.Movement.Data;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private AnimationController _animator;

        [SerializeField]
        private HorizontalMovementData _horizontalMovementData;
 
        [SerializeField]
        private JumperData _jumperData;
        

        private HorizontalMover _horizontalMover;
        private Jumper _jumper;
        private void Start()
        {
            Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
            _jumper = new Jumper(rigidBody, _jumperData);
            _horizontalMover = new HorizontalMover(rigidBody, _horizontalMovementData);
        }

        private void Update()
        {
            UpdateAnimations();
        }

        private void UpdateAnimations()
        {
            _animator.PlayAnimation(AnimationTypeEnum.Idle, true);
            _animator.PlayAnimation(AnimationTypeEnum.Run, _horizontalMover.IsMoving);
            _animator.PlayAnimation(AnimationTypeEnum.Jump, !_jumper.IsGrounded());
        }

        public void MoveHorizontally(float direction) => _horizontalMover.MoveHorizontally(direction);
        
        public void Jump() => _jumper.Jump();
        
        public void LongJump() => _jumper.LongJump();
    }
}
