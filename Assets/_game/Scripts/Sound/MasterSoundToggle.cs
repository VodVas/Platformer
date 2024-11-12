using UnityEngine;
using UnityEngine.Audio; 
using UnityEngine.UI;

public class MasterSoundToggle : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private Toggle _toggle;

    private float _maxVolume = 0f;
    private float _minVolume = -80f;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        _audioMixer.GetFloat(AudioMixerParameterKeeper.MasterVolume, out float currentVolume);
        _toggle.isOn = currentVolume > -79f;
        _toggle.onValueChanged.AddListener(ToggleMusic);
    }

    private void OnDestroy()
    {
        _toggle.onValueChanged.RemoveListener(ToggleMusic);
    }

    public void ToggleMusic(bool isEnabled)
    {
        if (isEnabled)
        {
            _audioMixer.SetFloat(AudioMixerParameterKeeper.MasterVolume, _maxVolume);
        }
        else
        {
            _audioMixer.SetFloat(AudioMixerParameterKeeper.MasterVolume, _minVolume);
        }
    }
}