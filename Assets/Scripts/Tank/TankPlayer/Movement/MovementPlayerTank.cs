using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MovementPlayerTank : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private AudioSource _movementSource;
    [SerializeField] private float _fadeDuration = 0.01f;
    //[SerializeField] private Animator _animator;

    private InputsPlayer _inputsPlayer;
    private float _turningSpeed = 8f;
    private bool _isMoving;
    private Coroutine _fadeCoroutine;

    private void Awake()
    {
        _inputsPlayer = new InputsPlayer();
        //_animator.enabled = false;
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
        Vector2 moveDirection = _inputsPlayer.Player.Move.ReadValue<Vector2>();

        bool isCurrentlyMoving = moveDirection != Vector2.zero;

        if (isCurrentlyMoving && !_isMoving)
        {
            if (_fadeCoroutine != null)
            {
                StopCoroutine(_fadeCoroutine);
                _fadeCoroutine = null;
            }
            _movementSource.volume = 0.5f;
            _movementSource.Play();

            //_animator.enabled = true;
        }
        else if (!isCurrentlyMoving && _isMoving)
        {
            if (_fadeCoroutine != null)
            {
                StopCoroutine(_fadeCoroutine);
            }

            _fadeCoroutine = StartCoroutine(FadeOut());
            //_animator.enabled = false;
        }

        _isMoving = isCurrentlyMoving;

        Move(moveDirection);
        TurnCourse(moveDirection);
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

    public void OffMovement()
    {
        this.enabled = false;
    }

    private void Move(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        _meshAgent.destination = transform.position + moveDirection * _moveSpeed * Time.fixedDeltaTime;
    }

    private void TurnCourse(Vector2 course)
    {
        if(course != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3( course.x, 0, course.y));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _turningSpeed * Time.deltaTime);
        }
    }
}
