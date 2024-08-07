using System.Collections;
using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    [SerializeField] private PlayerRadar _playerRadar;
    [SerializeField] private PlayerAttack _playerAttask;
    [SerializeField] private Player _player;
    [SerializeField] private MovementPlayerTank _movement;

    private Coroutine _coroutine;

    private void Start()
    {
        //_playerRadar.enabled = true;
        //_playerAttask.enabled = false;

        _coroutine = StartCoroutine(DestroyEnemies());
    }

    private IEnumerator DestroyEnemies()
    {
        while(true)
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

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ZoneFinal>())
        {
            StopCoroutine(_coroutine);

            _playerRadar.enabled = false;
            _movement.enabled  = false;

            _playerAttask.enabled = true;
        }
    }
    //private void Update()
    //{
    //    if (_player.Target != null)
    //    {
    //        if (Vector3.Distance(transform.position, _player.Target.transform.position) < _playerRadar.FieldView)
    //        {
    //            _playerRadar.enabled = false;
    //            _playerAttask.enabled = true;
    //        }
    //        else
    //        {
    //            _player.LoseTarget();
    //        }
    //    }
    //    else
    //    {
    //        _playerRadar.enabled = true;
    //        _playerAttask.enabled = false;
    //    }
    //}
}
