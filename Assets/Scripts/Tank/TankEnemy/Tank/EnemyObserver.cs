using UnityEngine;

public class EnemyObserver : MonoBehaviour
{
    [SerializeField] private EnemyRadar _enemyRadar;
    [SerializeField] private EnemyAttack _enemyAttack;

    [SerializeField] private Enemy _enemy;

    private void Start()
    {
        _enemyRadar.enabled = true;
        _enemyAttack.enabled = false;
    }

    private void Update()
    {
        if (_enemy.Player != null)
        {
            if (Vector3.Distance(transform.position, _enemy.Player.transform.position) < _enemyRadar.FieldView)
            {
                _enemyRadar.enabled = false;
                _enemyAttack.enabled = true;
            }
            else
            {
                _enemy.LosePlayer();
            }
        }
        else
        {
            _enemyRadar.enabled = true;
            _enemyAttack.enabled = false;
        }
    }
}