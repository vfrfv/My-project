using Tanks.TankPlayer;
using UnityEngine;

namespace Tanks.TankEnemy.Tank
{
    public class EnemyActionController : MonoBehaviour
    {
        [SerializeField] private Radar _radar;
        [SerializeField] private Attack _attack;

        [SerializeField] private Enemy _enemy;

        private void Start()
        {
            _radar.enabled = true;
            _attack.enabled = false;
        }

        private void Update()
        {
            if (_enemy.Target != null)
            {
                if (Vector3.Distance(transform.position, _enemy.Target.transform.position) < _radar.FieldView)
                {
                    _radar.enabled = false;
                    _attack.enabled = true;
                }
                else
                {
                    _enemy.LoseTarget();
                }
            }
            else
            {
                _radar.enabled = true;
                _attack.enabled = false;
            }
        }
    }
}