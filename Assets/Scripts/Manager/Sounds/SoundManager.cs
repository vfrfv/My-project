using UnityEngine;

namespace Assets.Scripts.Manager.Sounds
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _soundBackground;
        [SerializeField] private AudioSource _soundBossBackground;

        private void Start()
        {
            _soundBackground.Play();
            _soundBossBackground.Stop();
        }

        public void TurnOnBossBattle()
        {
            _soundBackground.Stop();
            _soundBossBackground.Play();
        }
    }
}