using UnityEngine;
using UnityEngine.Audio; 
using UnityEngine.UI;

public class MuteToggler : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;

    private Toggle _toggle;
    private float _maxVolume = 0f;
    private float _minVolume = -80f;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        if (_audioMixer.audioMixer.GetFloat(_audioMixer.name, out float currentVolume))
        {
            _toggle.isOn = currentVolume > -79f;
        }
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleMusic);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleMusic);
    }

    public void ToggleMusic(bool isEnabled)
    {
        if (isEnabled)
        {
            _audioMixer.audioMixer.SetFloat(_audioMixer.name, _maxVolume);
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(_audioMixer.name, _minVolume);
        }
    }
}