using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _tower;
    [SerializeField] private Animator _animator;

    public Transform Tower => _tower;
    public Transform ShootPoint => _shootPoint;

    public Animator Animator => _animator;
}
