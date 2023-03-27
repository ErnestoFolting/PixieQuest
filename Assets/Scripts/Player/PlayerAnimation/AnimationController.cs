using UnityEngine;

namespace Player.PlayerAnimation
{
    public abstract class AnimationController: MonoBehaviour
    {
        private AnimationTypeEnum _currentAnimationType;   
        public void PlayAnimation(AnimationTypeEnum animationType, bool shouldEnable)
        {
            if (!shouldEnable)
            {
                if (_currentAnimationType == AnimationTypeEnum.Idle || _currentAnimationType != animationType) return;
                _currentAnimationType = AnimationTypeEnum.Idle;
                PlayAnimation(_currentAnimationType);
                return;
            }
            if (_currentAnimationType > animationType) return;

            _currentAnimationType = animationType;
            PlayAnimation(_currentAnimationType);
        }

        protected abstract void PlayAnimation(AnimationTypeEnum animationType);
    }
}