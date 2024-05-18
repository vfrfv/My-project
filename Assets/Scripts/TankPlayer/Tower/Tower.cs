using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Tower : MonoBehaviour
{
    [SerializeField] private PlayerWeapon _weapon;
    [SerializeField] private LayerMask _layerMask;

    private SearchEnemyState _radar;
    private List<Enemy> _enemyList;
    private float _turningSpeed = 5f;
    private bool _canShoot;

    public bool CanShoot => _enemyList.Count > 0;

    private void Awake()
    {
        _enemyList = new List<Enemy>();
        _radar = GetComponent<SearchEnemyState>();
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

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

        if (_enemyList.Count > 0)
        {
            Enemy targetEnemy = _enemyList[0];
            LookAtDirection(targetEnemy);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    _weapon.Shoot();
                }
            }
        }
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
