using UnityEngine;

namespace Tanks.Controllers
{
    public class TankAnimation : MonoBehaviour
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