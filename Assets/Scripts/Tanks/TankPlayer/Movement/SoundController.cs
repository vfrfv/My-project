using System.Collections;
using UnityEngine;

namespace Tanks.TankPlayer.Movement
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource _movementSource;
        [SerializeField] private float _fadeDuration = 0.01f;

        private Coroutine _fadeCoroutine;

        public void PlaySound(bool isMoving)
        {
            if (isMoving && !_movementSource.isPlaying)
            {
                StopFadeCoroutine();

                _movementSource.volume = 0.5f;
                _movementSource.Play();
            }
            else if (!isMoving && _movementSource.isPlaying)
            {
                StartFadeOut();
            }
        }

        private IEnumerator FadeOut()
        {
            float startVolume = _movementSource.volume;
            for (float t = 0; t < _fadeDuration; t += Time.deltaTime)
            {
                _movementSource.volume = Mathf.Lerp(startVolume, 0, t / _fadeDuration);
                yield return null;
            }

            _movementSource.volume = 0;
            _movementSource.Stop();
        }

        private void StopFadeCoroutine()
        {
            if (_fadeCoroutine != null)
            {
                StopCoroutine(_fadeCoroutine);
                _fadeCoroutine = null;
            }
        }

        private void StartFadeOut()
        {
            StopFadeCoroutine();
            _fadeCoroutine = StartCoroutine(FadeOut());
        }
    }
}