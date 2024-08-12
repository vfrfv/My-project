using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AdjustVolume : MonoBehaviour
{
    const string SFXGroup = "SFX";
    const string MusicGroup = "Music";

    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _SFXVolume;

    private int _minimumVolumeLevel = -80;

    public void ChangeVolumeMusic()
    {
        _audioMixerGroup.audioMixer.SetFloat(MusicGroup, Mathf.Lerp(_minimumVolumeLevel, 0, _musicVolume.value));
    }

    public void ChangeVolumeSFX()
    {
        _audioMixerGroup.audioMixer.SetFloat(SFXGroup, Mathf.Lerp(_minimumVolumeLevel, 0, _SFXVolume.value));
    }
}
