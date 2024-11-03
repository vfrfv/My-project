using UnityEngine;

namespace Tanks.TankPlayer.Movement
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void ControlAnimation(bool isMoving)
        {
            if (isMoving && !_animator.enabled)
            {
                _animator.enabled = true;
            }
            else if (!isMoving && _animator.enabled)
            {
                DisableMotionAnimation();
            }
        }

        public void InstallAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void DisableMotionAnimation()
        {
            _animator.enabled = false;
        }
    }
}