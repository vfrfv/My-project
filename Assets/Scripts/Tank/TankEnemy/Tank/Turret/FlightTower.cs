using System;
using System.Collections;
using UnityEngine;

public class FlightTower : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private Enemy _bossEnemy;
    [SerializeField] private SmoothBar _smoothBar;
    [SerializeField] AnimationCurve _curve;
    [SerializeField] private EnemyAttack _enemyAttack;

    private float _points = 0;
    private float _totalPoints;

    public event Action Flew;
    public event Action AchievedGoal;
    public event Action<float> NumberPointsChanged;
    public event Action<float> PointsTransferredPlayer;
    private Coroutine _coroutine;

    public float TotalPoints => _totalPoints;

    private void Start()
    {
        _bossEnemy.Died += LaunchTower;
    }
    private void LaunchTower(Enemy enemy)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        else
        {
            _coroutine = StartCoroutine(Fly(_enemyAttack));
        }

        _bossEnemy.Died -= LaunchTower;
    }

    private IEnumerator Fly(EnemyAttack enemyAttack)
    {
        Flew?.Invoke();

        _totalPoints = _smoothBar.Value.Value * 100;

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

            _points = t * _totalPoints;
            NumberPointsChanged?.Invoke(_points);

            enemyAttack.gameObject.transform.position = newPosition;

            yield return null;
        }

        _points = _totalPoints;
        NumberPointsChanged?.Invoke(_points);
        PointsTransferredPlayer?.Invoke(_totalPoints);

        enemyAttack.gameObject.transform.position = _point.transform.position;
        AchievedGoal?.Invoke();
    }
}
