using Agava.WebUtility;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Tanks.TankPlayer.Movement
{
    public class MovementPlayerTank : MonoBehaviour
    {
        [SerializeField] private float _direction = 100;
        [SerializeField] private NavMeshAgent _meshAgent;
        [SerializeField] private AudioSource _movementSource;
        [SerializeField] private float _fadeDuration = 0.01f;
        [SerializeField] private Animator _animator;
        [SerializeField] private Joystick _joystick;

        private InputsPlayer _inputsPlayer;
        private readonly float _turningSpeed = 8f;
        private bool _isMoving;
        private Coroutine _fadeCoroutine;
        private Vector2 _moveDirection;

        private void Awake()
        {
            _inputsPlayer = new InputsPlayer();
        }

        private void Start()
        {
            DisableMotionAnimation();
        }

        private void OnEnable()
        {
            _inputsPlayer.Enable();
        }

        private void OnDisable()
        {
            _inputsPlayer.Disable();
        }

        private void FixedUpdate()
        {
            if (Device.IsMobile)
            {
                if (!_joystick.gameObject.activeSelf == false)
                {
                    _joystick.gameObject.SetActive(true);
                }

                _moveDirection = _joystick.Direction;
            }
            else
            {
                if (_joystick.gameObject.activeSelf)
                {
                    _joystick.gameObject.SetActive(false);
                }

                _moveDirection = _inputsPlayer.Player.Move.ReadValue<Vector2>();
            }

            _isMoving = _moveDirection != Vector2.zero;

            ControlSound(_isMoving);
            ControlAnimation(_isMoving);

            Move(_moveDirection);
            TurnCourse(_moveDirection);
        }

        private IEnumerator FadeOut()
        {
            float startVolume = _movementSource.volume;

            for (float t = 0; t < _fadeDuration; t += Time.deltaTime)
            {
                _movementSource.volume = Mathf.Lerp(startVolume, 0, t / _fadeDuration);
                yield return null;
            }

            _movementSource.volume = 0;
            _movementSource.Stop();
        }

        public void InstallAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void DisableMotionAnimation()
        {
            _animator.enabled = false;
        }

        private void ControlAnimation(bool isMoving)
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

        private void ControlSound(bool isMoving)
        {
            if (isMoving && !_movementSource.isPlaying)
            {
                if (_fadeCoroutine != null)
                {
                    StopCoroutine(_fadeCoroutine);
                    _fadeCoroutine = null;
                }

                _movementSource.volume = 0.5f;
                _movementSource.Play();
            }
            else if (!isMoving && _movementSource.isPlaying)
            {
                if (_fadeCoroutine != null)
                {
                    StopCoroutine(_fadeCoroutine);
                }

                _fadeCoroutine = StartCoroutine(FadeOut());
            }
        }

        private void Move(Vector2 direction)
        {
            Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
            _meshAgent.destination = transform.position + moveDirection * _direction * Time.fixedDeltaTime;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(_meshAgent.destination, 1);
        }

        private void TurnCourse(Vector2 course)
        {
            if (course != Vector2.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(course.x, 0, course.y));
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _turningSpeed * Time.deltaTime);
            }
        }
    }
}