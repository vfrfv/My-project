using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Tanks.TankPlayer.Movement
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource _playerMovementSource;
        [SerializeField] private float _fadeDuration = 0.01f;
        [SerializeField] private AudioSource _sfxAudioSourcePrefab;
        [SerializeField] private AudioClip _playerDeathSound;
        [SerializeField] private AudioClip _enemyDeathSound;

        private Coroutine _fadeCoroutine;

        public void PlaySound(bool isMoving)
        {
            if (isMoving && !_playerMovementSource.isPlaying)
            {
                StopFadeCoroutine();

                _playerMovementSource.volume = 0.5f;
                _playerMovementSource.Play();
            }
            else if (!isMoving && _playerMovementSource.isPlaying)
            {
                StartFadeOut();
            }
        }

        public void PlaySoundPlayerDeath()
        {
            PlaySoundDeath(_playerDeathSound);
        }

        public void PlaySoundEnemyDeath()
        {
            PlaySoundDeath(_enemyDeathSound);
        }

        private IEnumerator FadeOut()
        {
            float startVolume = _playerMovementSource.volume;
            for (float t = 0; t < _fadeDuration; t += Time.deltaTime)
            {
                _playerMovementSource.volume = Mathf.Lerp(startVolume, 0, t / _fadeDuration);
                yield return null;
            }

            _playerMovementSource.volume = 0;
            _playerMovementSource.Stop();
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
        

        private void PlaySoundDeath(AudioClip audioClip)
        {
            AudioSource sfxInstance = Instantiate(_sfxAudioSourcePrefab, transform.position, Quaternion.identity);
            sfxInstance.PlayOneShot(audioClip);

            Destroy(sfxInstance.gameObject, audioClip.length);
        }
    }
}