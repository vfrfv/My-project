using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _health = 5f;
    private Enemy _target;

    public Enemy Target => _target;

    private void OnTriggerEnter(Collider other)
    {
       
    }

    public void SetTarget(Enemy enemy)
    {
        _target = enemy;
    }

    public void LoseTarget()
    {
        _target = null;
    }

    private void TakeDamage()
    {
        _health--;
    }
}
