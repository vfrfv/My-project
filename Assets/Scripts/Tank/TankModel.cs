using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _tower;

    public Transform Tower => _tower;
    public Transform ShootPoint => _shootPoint;
}
