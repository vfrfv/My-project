using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoringPoints : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private FlightTower _flightTower;

    private float _glasses = 0;
    private Coroutine _coroutine;

    private void Start()
    {
        _flightTower.Flew += StartAddPoints;
        _text.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Earth earth))
        {
            StopCoroutine(_coroutine);

            _flightTower.Flew -= StartAddPoints;
        }
    }

    private void StartAddPoints()
    {
        _text.enabled = true;

        _coroutine = StartCoroutine(AddPoints());
    }

    private IEnumerator AddPoints()
    {
        while(true)
        {
            _glasses++;
            _text.text = _glasses.ToString();

            yield return new WaitForSeconds(0.01f);
        }
    }
}
