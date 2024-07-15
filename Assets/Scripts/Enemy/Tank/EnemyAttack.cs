using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private EnemyWeapon _weapon;
    [SerializeField] private Enemy _enemy;

    private float _turningSpeed = 8;
    private bool _hooked = false;

    private void Update()
    {
        //Ray ray = new Ray(transform.position, transform.forward);
        //Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

        if (_enemy.Player != null)
        {
            LookAtDirection(_enemy.Player);

            //if (Physics.Raycast(ray, out RaycastHit hit))
            //{
            if (_hooked == true)
            {
                _weapon.Shoot();
            }
            //}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _hooked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _hooked = false;
    }

    private void LookAtDirection(Player player)
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _turningSpeed * Time.deltaTime);
        }
    }
}
