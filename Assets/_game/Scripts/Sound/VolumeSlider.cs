using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public abstract class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;

    private Slider _slider;
    private float _maxVolume = 0f;
    private float _minVolume = -80f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        if (_audioMixer.audioMixer.GetFloat(GetVolumeParameterName(), out float currentVolume))
        {
            _slider.value = Mathf.InverseLerp(_minVolume, _maxVolume, currentVolume);
        }

        _slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnDestroy()
    {
        if (_slider != null)
        {
            _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }
    }

    private void OnSliderValueChanged(float value)
    {
        float newVolume = Mathf.Lerp(_minVolume, _maxVolume, value);
        _audioMixer.audioMixer.SetFloat(GetVolumeParameterName(), newVolume);
    }

    protected abstract string GetVolumeParameterName();
}