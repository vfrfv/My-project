using System.Collections;
using UnityEngine;

namespace Tanks.TankObserwers
{
    public class TankObserver : MonoBehaviour
    {
        [SerializeField] protected Radar _radar;
        [SerializeField] protected Attack _attask;
        [SerializeField] protected TankBase _tank;


        protected Coroutine _coroutine;
        protected bool _tankObserverWorks = true;

        protected void Start()
        {
            _coroutine = StartCoroutine(DestroyEnemies());
        }

        protected IEnumerator DestroyEnemies()
        {
            while (_tankObserverWorks)
            {
                if (_tank.Target != null)
                {
                    if (Vector3.Distance(transform.position, _tank.Target.transform.position) < _radar.FieldView)
                    {
                        _radar.enabled = false;
                        _attask.enabled = true;
                    }
                    else
                    {
                        _tank.LoseTarget();
                    }
                }
                else
                {
                    _radar.enabled = true;
                    _attask.enabled = false;
                }

                yield return null;
            }
        }
    }
}