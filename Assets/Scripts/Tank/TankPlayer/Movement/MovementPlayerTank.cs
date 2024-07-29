using System;
using UnityEngine;
using UnityEngine.AI;

public class MovementPlayerTank : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private NavMeshAgent _meshAgent;

    private InputsPlayer _inputsPlayer;
    private float _turningSpeed = 8f;

    private void Awake()
    {
        _inputsPlayer = new InputsPlayer();
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

        Move(moveDirection);
        TurnCourse(moveDirection);
    }

    public void OffMovement()
    {
        this.enabled = false;
    }

    private void Move(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        _meshAgent.destination = transform.position + moveDirection * _moveSpeed * Time.fixedDeltaTime;
        //transform.position += moveDirection * _moveSpeed * Time.deltaTime;
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
