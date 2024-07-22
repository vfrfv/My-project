using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class FlightTower : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private Enemy _bossEnemy;
    [SerializeField] private SmoothBar _smoothBar;
    [SerializeField] AnimationCurve _curve;
    [SerializeField] private EnemyAttack _enemyAttack;

    private int _launchForce = 150;

    public event Action Flew;
    public event Action AchievedGoal;

    private void Start()
    {
        _bossEnemy.Died += LaunchTower;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Flew?.Invoke();
            StartCoroutine(Fly(_enemyAttack));
        }
    }

    private void LaunchTower(Enemy enemy)
    {
        Flew?.Invoke();
        StartCoroutine(Fly(_enemyAttack));

        _bossEnemy.Died -= LaunchTower;
    }

    private IEnumerator Fly(EnemyAttack enemyAttack)
    {
        Vector3 startPoint = transform.position;
        Vector3 targetPosition = _point.transform.position;
        float speed = 25f;

        float distance = Vector3.Distance(startPoint, targetPosition);
        float verticalScaleFactor = distance * 0.1f;

        float duration = distance / speed;

        for (float t = 0f; t <= 1f; t += Time.deltaTime / duration)
        {
            float verticalPosition = _curve.Evaluate(t);
            Vector3 newPosition = Vector3.Lerp(startPoint, targetPosition, t) + Vector3.up * (verticalPosition * verticalScaleFactor);

            enemyAttack.gameObject.transform.position = newPosition;

            yield return null;
        }

        enemyAttack.gameObject.transform.position = _point.transform.position;
        AchievedGoal?.Invoke();
    }
}
