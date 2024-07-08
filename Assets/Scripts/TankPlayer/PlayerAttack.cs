using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerWeapon _weapon;
    [SerializeField] private LayerMask _enemy;

    [SerializeField] private Player _player;
    private float _turningSpeed = 8;

    //private void Awake()
    //{
    //    _player = GetComponent<Player>();
    //}

    private void LateUpdate()
    {
        if (_player.Target != null)
        {
            LookAtDirection(_player.Target);

            //Ray ray = new Ray(transform.position, transform.forward);
            //Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

            //var hits = Physics.RaycastAll(ray,10, _enemy);

            //foreach (var hit in hits)
            //{
            //    Debug.Log(hit.collider.name);

            //    if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
            //    {
            _weapon.Shoot();
            //    }   
            //}
        }
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
