using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneFinal : MonoBehaviour
{
    [SerializeField] private Enemy _boss;

    private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out MovementPlayerTank movement))
        {
            movement.OffMovement();
        }
    }
}
