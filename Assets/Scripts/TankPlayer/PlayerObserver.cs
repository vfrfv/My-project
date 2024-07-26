using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    [SerializeField] private PlayerRadar _playerRadar;
    [SerializeField] private PlayerAttack _playerAttask;
    [SerializeField] private Player _player;

    private bool _playerInFinalZone = false;

    private void Start()
    {
        _playerRadar.enabled = true;
        _playerAttask.enabled = false;
    }

    private void Update()
    {
        if (_player.Target != null)
        {
            if (Vector3.Distance(transform.position, _player.Target.transform.position) < _playerRadar.FieldView)
            {
                _playerRadar.enabled = false;
                _playerAttask.enabled = true;
            }
            else
            {
                _player.LoseTarget();
            }
        }
        else
        {
            _playerRadar.enabled = true;
            _playerAttask.enabled = false;
        }
    }
}
