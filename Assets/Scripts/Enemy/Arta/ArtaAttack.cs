using System.Collections;
using UnityEngine;

public class ArtaAttack : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Player _target;

    [SerializeField] AnimationCurve _curve;
    [SerializeField] private ArtaMissile _prefabMissile;

    private void Start()
    {
        StartCoroutine(StartShoot());
    }

    private void Update()
    {
        LookAtDirection(_target);
    }

    private void Shoot()
    {
        ArtaMissile missile = Instantiate(_prefabMissile);

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

    private IEnumerator Fly(ArtaMissile missile)
    {
        Vector3 startPoint = _shootPoint.position;
        Vector3 targetPosition = _target.transform.position;
        float duration = 2f; 

        for (float t = 0f; t <= 1f; t += Time.deltaTime / duration)
        {
            float verticalPosition = _curve.Evaluate(t);
            Vector3 newPosition = Vector3.Lerp(startPoint, targetPosition, t) + Vector3.up * (verticalPosition * 3);

            if (missile == null)
            {
                yield break;
            }

            Vector3 previousPosition = missile.transform.position; 
            missile.transform.position = newPosition;

            Vector3 direction = (newPosition - previousPosition).normalized; 

            if (direction != Vector3.zero) 
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);
                missile.transform.rotation = toRotation;
            }


            yield return null;
        }

        Destroy(missile.gameObject);
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
