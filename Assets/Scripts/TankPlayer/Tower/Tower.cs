using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Tower : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private Radar _radar;
    private List<Enemy> _enemyList;
    private float _turningSpeed = 8f;
    private bool _canShoot;

    public bool CanShoot => _enemyList.Count > 0;

    private void Awake()
    {
        _enemyList = new List<Enemy>();
        _radar = GetComponent<Radar>();
    }

    private void OnEnable()
    {
        _radar.EnemyDetected += AddEnemy;
        _radar.EnemyLost += RemoveEnemy;
    }

    private void OnDisable()
    {
        _radar.EnemyDetected -= AddEnemy;
        _radar.EnemyLost -= RemoveEnemy;
    }

    private void AddEnemy(Enemy enemy)
    {
        _enemyList.Add(enemy);
        enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        RemoveEnemy(enemy);
    }

    private void RemoveEnemy(Enemy enemy)
    {
        _enemyList.Remove(enemy);
        enemy.Died -= OnEnemyDied;
    }

    private void Update()
    {
        if (_enemyList.Count > 0)
        {
            Enemy targetEnemy = _enemyList[0];

            LookAtDirection(targetEnemy);
            _weapon.Shoot();
        }
    }

    private void LookAtDirection(Enemy enemy)
    {
        if (enemy != null)
        {
            Vector3 direction = enemy.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _turningSpeed * Time.deltaTime);
        }
    }
}
