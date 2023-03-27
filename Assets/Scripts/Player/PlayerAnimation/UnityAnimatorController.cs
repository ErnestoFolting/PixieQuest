using UnityEngine;

namespace Player.PlayerAnimation
{
    [RequireComponent(typeof(Animator))]
    public class UnityAnimatorController: AnimationController
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        protected override void PlayAnimation(AnimationTypeEnum animationType)
        {
            _animator.SetInteger(nameof(AnimationTypeEnum),(int)animationType);
        }
    }
}