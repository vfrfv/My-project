using Agava.WebUtility;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Training : MonoBehaviour
{
    private const string TrainingCompletedKey = "TrainingCompleted";

    [SerializeField] private Image _imageArm;
    [SerializeField] private Image _imageKeys;

    [SerializeField] private Image _imageSlide1;
    [SerializeField] private Image _imageSlide2;
    [SerializeField] private Image _imageSlide3;

    [SerializeField] private Zone _zone;

    private bool _isPressed = false;

    private void Awake()
    {
        _zone.EnemiesAreOver += StartShowThirdSlide;

        _imageArm.gameObject.SetActive(false);
        _imageKeys.gameObject.SetActive(false);

        _imageSlide1.gameObject.SetActive(false);
        _imageSlide2.gameObject.SetActive(false);
        _imageSlide3.gameObject.SetActive(false);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(TrainingCompletedKey))
        {
            gameObject.SetActive(false);
            return;
        }

        StartCoroutine(OffUIManagement());
    }

    private void OnDisable()
    {
        _zone.EnemiesAreOver -= StartShowThirdSlide;
    }

    private IEnumerator OffUIManagement()
    {
        while (_isPressed == false)
        {
            if (Device.IsMobile)
            {
                _imageArm.gameObject.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    if (_imageArm.gameObject.activeSelf == true)
                    {
                        _imageArm.gameObject.SetActive(false);

                        StartCoroutine(ShowFirstSlide());
                        _isPressed = true;
                    }
                }
            }
            else
            {
                _imageKeys.gameObject.SetActive(true);

                if (Input.anyKeyDown)
                {
                    if (_imageKeys.gameObject.activeSelf == true)
                    {
                        _imageKeys.gameObject.SetActive(false);

                        StartCoroutine(ShowFirstSlide());
                        _isPressed = true;
                    }
                }
            }

            yield return null;
        }
    }

    private IEnumerator ShowFirstSlide()
    {
        bool isPressed = false;

        while (isPressed == false)
        {
            yield return new WaitForSecondsRealtime(2);

            _imageSlide1.gameObject.SetActive(true);
            Time.timeScale = 0.1f;

            yield return new WaitForSecondsRealtime(1);

            while (!Input.GetMouseButtonDown(0) && !Input.anyKeyDown)
            {
                yield return null;
            }

            _imageSlide1.gameObject.SetActive(false);
            Time.timeScale = 1;

            StartCoroutine(ShowSecondSlide());
            isPressed = true;
        }
    }

    private IEnumerator ShowSecondSlide()
    {
        bool isPressed = false;

        while (isPressed == false)
        {
            yield return new WaitForSecondsRealtime(2);

            _imageSlide2.gameObject.SetActive(true);
            Time.timeScale = 0.1f;

            yield return new WaitForSecondsRealtime(1);

            while (!Input.GetMouseButtonDown(0) && !Input.anyKeyDown)
            {
                yield return null;
            }

            _imageSlide2.gameObject.SetActive(false);
            Time.timeScale = 1;

            isPressed = true;
        }
    }

    private void StartShowThirdSlide()
    {
        StartCoroutine(ShowThirdSlide());
    }

    private IEnumerator ShowThirdSlide()
    {
        bool isPressed = false;

        while (isPressed == false)
        {
            _imageSlide3.gameObject.SetActive(true);
            Time.timeScale = 0.1f;

            yield return new WaitForSecondsRealtime(1);

            while (!Input.GetMouseButtonDown(0) && !Input.anyKeyDown)
            {
                yield return null;
            }

            _imageSlide3.gameObject.SetActive(false);
            Time.timeScale = 1;

            PlayerPrefs.SetInt(TrainingCompletedKey, 1);
            PlayerPrefs.Save();

            isPressed = true;
        }
    }
}