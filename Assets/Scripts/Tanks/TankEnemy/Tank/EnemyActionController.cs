using UnityEngine;

namespace Tanks.TankEnemy.Tank
{
    public class EnemyActionController : MonoBehaviour
    {
        [SerializeField] private Radar _enemyRadar;
        [SerializeField] private EnemyAttack _enemyAttack;

        [SerializeField] private Enemy _enemy;

        private void Start()
        {
            _enemyRadar.enabled = true;
            _enemyAttack.enabled = false;
        }

        private void Update()
        {
            if (_enemy.Target != null)
            {
                if (Vector3.Distance(transform.position, _enemy.Target.transform.position) < _enemyRadar.FieldView)
                {
                    _enemyRadar.enabled = false;
                    _enemyAttack.enabled = true;
                }
                else
                {
                    _enemy.LoseTarget();
                }
            }
            else
            {
                _enemyRadar.enabled = true;
                _enemyAttack.enabled = false;
            }
        }
    }
}