using Agava.WebUtility;
using Infrastructure.Zones;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
    public class Training : MonoBehaviour
    {
        private const string TrainingCompletedKey = "TrainingCompleted";

        [SerializeField] private Image _imageArm;
        [SerializeField] private Image _imageKeys;

        [SerializeField] private Image _learningSlide1;
        [SerializeField] private Image _learningSlide2;
        [SerializeField] private Image _learningSlide3;

        [SerializeField] private Zone _zone;

        private bool _isPressed = false;

        private void Awake()
        {
            _zone.EnemiesAreOver += StartShowThirdSlide;

            _imageArm.gameObject.SetActive(false);
            _imageKeys.gameObject.SetActive(false);

            _learningSlide1.gameObject.SetActive(false);
            _learningSlide2.gameObject.SetActive(false);
            _learningSlide3.gameObject.SetActive(false);
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

                _learningSlide1.gameObject.SetActive(true);
                Time.timeScale = 0.1f;

                yield return new WaitForSecondsRealtime(1);

                while (!Input.GetMouseButtonDown(0) && !Input.anyKeyDown)
                {
                    yield return null;
                }

                _learningSlide1.gameObject.SetActive(false);
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

                _learningSlide2.gameObject.SetActive(true);
                Time.timeScale = 0.1f;

                yield return new WaitForSecondsRealtime(1);

                while (!Input.GetMouseButtonDown(0) && !Input.anyKeyDown)
                {
                    yield return null;
                }

                _learningSlide2.gameObject.SetActive(false);
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
                _learningSlide3.gameObject.SetActive(true);
                Time.timeScale = 0.1f;

                yield return new WaitForSecondsRealtime(1);

                while (!Input.GetMouseButtonDown(0) && !Input.anyKeyDown)
                {
                    yield return null;
                }

                _learningSlide3.gameObject.SetActive(false);
                Time.timeScale = 1;

                PlayerPrefs.SetInt(TrainingCompletedKey, 1);
                PlayerPrefs.Save();

                isPressed = true;
            }
        }
    }
}