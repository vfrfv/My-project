using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    [SerializeField] private PlayerRadar _playerRadar;
    [SerializeField] private PlayerAttack _playerAttask;
    [SerializeField] private MovementPlayerTank _movementPlayer;

    [SerializeField] private ZoneFinal _zoneFinal;
    [SerializeField] private Player _player;

    private bool _playerInFinalZone = false;

    private void Start()
    {
        _movementPlayer.enabled = true;
        _playerRadar.enabled = true;
        _playerAttask.enabled = false;

        _zoneFinal.PlayerInZone += StopPlayer;
    }

    private void Update()
    {
        if (_player.Target == null)
        {
            _playerRadar.enabled = true;
        }
        else
        {
            if (_playerInFinalZone == false)
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
                _movementPlayer.enabled = false;
                _playerRadar.enabled = false;
                _playerAttask.enabled = true;
            }
        }

        //if (_player.Target != null)
        //{
        //    if (Vector3.Distance(transform.position, _player.Target.transform.position) < _playerRadar.FieldView)
        //    {
        //        _playerRadar.enabled = false;
        //        _playerAttask.enabled = true;
        //    }
        //    else
        //    {
        //        _player.LoseTarget();
        //    }
        //}
        //else
        //{
        //    _playerRadar.enabled = true;
        //    _playerAttask.enabled = false;
        //}
    }

    private void StopPlayer()
    {
        _playerInFinalZone = true;   
    }
}
