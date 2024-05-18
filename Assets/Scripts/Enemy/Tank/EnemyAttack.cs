using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyWeapon _weapon;

    [SerializeField] private Enemy _enemy;
    private float _turningSpeed = 8;

    //private void Awake()
    //{
    //    _enemy = GetComponent<Enemy>();
    //}

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

        if (_enemy.Player != null)
        {
            LookAtDirection(_enemy.Player);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<Player>(out Player player))
                {
                    _weapon.Shoot();
                }
            }
        }
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
