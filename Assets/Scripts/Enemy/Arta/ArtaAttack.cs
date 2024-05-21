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
        //Vector3 targetPosition = _target.transform.position;
        //Vector3 direction = targetPosition - transform.position;
        //missile.transform.rotation = Quaternion.LookRotation(direction);

        StartCoroutine(Fly(missile));
    }

    private IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();

            yield return new WaitForSeconds(3f);
        }
    }

    private IEnumerator Fly(ArtaMissile missile)
    {
        Vector3 startPoint = _shootPoint.position;
        Vector3 targetPosition = _target.transform.position;
        float duration = 1f; // Предполагаем, что ракета должна достичь цели за 1 секунду. Подкорректируйте по необходимости.

        for (float t = 0f; t <= 1f; t += Time.deltaTime / duration)
        {
            float verticalPosition = _curve.Evaluate(t);
            Vector3 newTestPosition = Vector3.Lerp(startPoint, targetPosition, t) + Vector3.up * (verticalPosition * 3);

            if (missile == null)
            {
                yield break;
            }

            Vector3 previousPosition = missile.transform.position; // Сохраняем текущую позицию перед её изменением
            missile.transform.position = newTestPosition;

            Vector3 direction = (newTestPosition - previousPosition).normalized; // Вычисляем направление на основе разницы между новой и предыдущей позицией

            if (direction != Vector3.zero) // Проверяем, что вектор направления валиден
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);
                missile.transform.rotation = toRotation; // Плавное вращение
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
