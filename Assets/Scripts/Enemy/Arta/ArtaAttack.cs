using System.Collections;
using UnityEngine;

public class ArtaAttack : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Player _target;

    [SerializeField] AnimationCurve _curve;
    [SerializeField] private ArtaBullet _prefabMissile;

    private void Start()
    {
        StartCoroutine(StartShoot());
    }

    private void Update()
    {
        LookAtDirection(_target);
    }

    public void GetNewTarget(Player target)
    {
        _target = target;
    }

    private void Shoot()
    {
        ArtaBullet missile = Instantiate(_prefabMissile);

        StartCoroutine(Fly(missile));
    }

    private IEnumerator StartShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            Shoot();
        }
    }

    private IEnumerator Fly(ArtaBullet bullet)
    {
        Vector3 startPoint = _shootPoint.position;
        Vector3 targetPosition = _target.transform.position;
        float speed = 10f;

        float distance = Vector3.Distance(startPoint, targetPosition);
        float verticalScaleFactor = distance * 0.1f;

        float duration = distance / speed;

        for (float t = 0f; t <= 1f; t += Time.deltaTime / duration)
        {
            float verticalPosition = _curve.Evaluate(t);
            Vector3 newPosition = Vector3.Lerp(startPoint, targetPosition, t) + Vector3.up * (verticalPosition * verticalScaleFactor);

            if (bullet == null)
            {
                yield break;
            }

            Vector3 previousPosition = bullet.transform.position; 
            bullet.transform.position = newPosition;

            Vector3 direction = (newPosition - previousPosition).normalized; 

            if (direction != Vector3.zero) 
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);
                bullet.transform.rotation = toRotation;
            }

            yield return null;
        }

        Destroy(bullet.gameObject);
    }

    private void LookAtDirection(Player player)
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 8 * Time.deltaTime);
        }
    }
}
