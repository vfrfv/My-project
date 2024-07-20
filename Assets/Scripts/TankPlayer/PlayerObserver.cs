using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    [SerializeField] private PlayerRadar _enemyRadar;
    [SerializeField] private PlayerAttack _playerAttask;

    [SerializeField] private Player _player;

    private void Start()
    {
        _enemyRadar.enabled = true;
        _playerAttask.enabled = false;
    }

    private void Update()
    {
        if (_player.Target != null)
        {
            if (Vector3.Distance(transform.position, _player.Target.transform.position) < _enemyRadar.FieldView)
            {
                _enemyRadar.enabled = false;
                _playerAttask.enabled = true;
            }
            else
            {
                _player.LoseTarget();
            }
        }
        else
        {
            _enemyRadar.enabled = true;
            _playerAttask.enabled = false;
        }
    }
}
