using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
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
        string parameterName = _audioMixer.name;

        if (_audioMixer.audioMixer.GetFloat(parameterName, out float currentVolume))
        {
            _slider.value = Mathf.InverseLerp(_minVolume, _maxVolume, currentVolume);
        }
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        string parameterName = _audioMixer.name;
        float newVolume = Mathf.Lerp(_minVolume, _maxVolume, value);

        _audioMixer.audioMixer.SetFloat(parameterName, newVolume);
    }
}