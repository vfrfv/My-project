using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player;

    public Player Player => _player;


    public event Action<Enemy> Died;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Missile>(out Missile missile))
        {
            Destroy(gameObject);
            Died?.Invoke(this);
        }
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void LosePlayer()
    {
        _player = null;
    }
}
