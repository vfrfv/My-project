using Cinemachine;
using System.Collections;
using Tanks.TankPlayer;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.Camers
{
    public class CityCamera : MonoBehaviour
    {
        [SerializeField] private Image _imageSlide;
        [SerializeField] private CinemachineVirtualCamera _cameraPlayer;
        [SerializeField] private CinemachineVirtualCamera _cityCamera;

        private void Awake()
        {
            _imageSlide.gameObject.SetActive(false);

            _cameraPlayer.gameObject.SetActive(true);
            _cityCamera.gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                _cameraPlayer.gameObject.SetActive(false);
                _cityCamera.gameObject.SetActive(true);

                StartCoroutine(ShowSlide());
            }
        }

        private IEnumerator ShowSlide()
        {
            bool isPressed = false;

            while (isPressed == false)
            {
                _imageSlide.gameObject.SetActive(true);
                Time.timeScale = 0.1f;

                yield return new WaitForSecondsRealtime(1);

                while (!Input.GetMouseButtonDown(0) && !Input.anyKeyDown)
                {
                    yield return null;
                }

                _imageSlide.gameObject.SetActive(false);
                Time.timeScale = 1;

                isPressed = true;
            }
        }
    }
}