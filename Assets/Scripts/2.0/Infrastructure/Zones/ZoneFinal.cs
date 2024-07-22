using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneFinal : MonoBehaviour
{
    [SerializeField] private Enemy _boss;

    public event Action PlayerInZone;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            PlayerInZone?.Invoke();

            player.SetTarget(_boss);
            _boss.SetTarget(player);
        }
    }
}
