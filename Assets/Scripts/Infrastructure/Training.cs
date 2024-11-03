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
            while (!_isPressed)
            {
                if (Device.IsMobile)
                {
                    ShowManagementTool(_imageArm);
                }
                else
                {
                    ShowManagementTool(_imageKeys);
                }

                yield return null;
            }
        }

        private void ShowManagementTool(Image image)
        {
            image.gameObject.SetActive(true);

            if (Input.anyKeyDown)
            {
                image.gameObject.SetActive(false);
                _isPressed = true;
                StartCoroutine(ShowSlideSequence());
            }
        }

        private IEnumerator ShowSlideSequence()
        {
            yield return ShowSlide(_learningSlide1);

            yield return ShowSlide(_learningSlide2);
        }

        private void StartShowThirdSlide()
        {
            StartCoroutine(ShowThirdSlide());
        }

        private IEnumerator ShowThirdSlide()
        {
            yield return ShowSlide(_learningSlide3);

            PlayerPrefs.SetInt(TrainingCompletedKey, 1);
            PlayerPrefs.Save();
        }

        private IEnumerator ShowSlide(Image slide)
        {
            slide.gameObject.SetActive(true);
            Time.timeScale = 0.1f;

            yield return new WaitForSecondsRealtime(1);

            while (!Input.GetMouseButtonDown(0) && !Input.anyKeyDown)
            {
                yield return null;
            }

            slide.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}