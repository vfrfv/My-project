using UnityEngine;
using UnityEngine.InputSystem.HID;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerWeapon _weapon;
    [SerializeField] private LayerMask _enemy;

    [SerializeField] private Player _player;

    private float _turningSpeed = 8;
    private bool _hooked = false;

    //private void Awake()
    //{
    //    _player = GetComponent<Player>();
    //}

    private void Update()
    {
        if (_player.Target != null)
        {
            LookAtDirection(_player.Target);

            Ray ray = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

            var hits = Physics.RaycastAll(ray, _enemy);

            Debug.Log(hits.Length);

            foreach (var hit in hits)
            {
                Debug.Log(hit.collider.name);

                if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    _weapon.Shoot();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            _hooked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _hooked = false ;
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
