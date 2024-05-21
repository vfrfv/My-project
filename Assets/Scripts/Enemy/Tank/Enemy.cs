using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , IHealth
{
    private Player _player;
    private int _health = 2;

    public Player Player => _player;

    public int Value => _health;

    public event Action<Enemy> Died;
    public event Action<int> Changed;

    private void Start()
    {
        Changed?.Invoke(_health);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Missile>(out Missile missile))
        {
            TakeDamage();
            Died?.Invoke(this);
        }
    }

    private void Update()
    {
        print(_health);
    }

    private void TakeDamage()
    {
        if(_health <= 0)
        {
            Die();
        }
        else
        {
            _health--;
            Changed?.Invoke(_health);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
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
