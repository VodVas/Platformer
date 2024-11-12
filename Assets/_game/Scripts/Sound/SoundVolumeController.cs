using UnityEngine;
using UnityEngine.Audio;

public class SoundVolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;

    private int _minVolume = -80;
    private int _maxVolume = 0;

    public void ToggleMusic(bool isEnabled)
    {
        if (isEnabled)
        {
            _audioMixer.audioMixer.SetFloat(AudioMixerParameterKeeper.MasterVolume, _maxVolume);
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(AudioMixerParameterKeeper.MasterVolume, _minVolume);
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat(AudioMixerParameterKeeper.MasterVolume, Mathf.Lerp(_minVolume, _maxVolume, volume));
    }

    public void ChangeVolumeSoundFX(float volume)
    {
        _audioMixer.audioMixer.SetFloat(AudioMixerParameterKeeper.SoundFXVolume, Mathf.Lerp(_minVolume, _maxVolume, volume));
    }

    public void ChangeVolumeBackgroundMusic(float volume)
    {
        _audioMixer.audioMixer.SetFloat(AudioMixerParameterKeeper.BackgroundMusicVolume, Mathf.Lerp(_minVolume, _maxVolume, volume));
    }
}