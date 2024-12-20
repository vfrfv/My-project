using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Manager.Sounds
{
    public class AdjustVolume : MonoBehaviour
    {
        private const string SFXGroup = "SFX";
        private const string MusicGroup = "Music";

        [SerializeField] private AudioMixerGroup _audioMixerGroup;

        [SerializeField] private Slider _musicVolume;
        [SerializeField] private Slider _SFXVolume;

        private readonly int _minimumVolumeLevel = -80;

        private void Start()
        {
            _musicVolume.onValueChanged.AddListener(ChangeVolumeMusic);
            _SFXVolume.onValueChanged.AddListener(ChangeVolumeSFX);
        }

        private void OnDestroy()
        {
            _musicVolume.onValueChanged.RemoveListener(ChangeVolumeMusic);
            _SFXVolume.onValueChanged.RemoveListener(ChangeVolumeSFX);
        }

        private void ChangeVolumeMusic(float value)
        {
            _audioMixerGroup.audioMixer.SetFloat(MusicGroup, Mathf.Lerp(_minimumVolumeLevel, 0, value));
        }

        private void ChangeVolumeSFX(float value)
        {
            _audioMixerGroup.audioMixer.SetFloat(SFXGroup, Mathf.Lerp(_minimumVolumeLevel, 0, value));
        }
    }
}