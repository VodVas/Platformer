using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBarDisplay : HealthDisplayBase
{
    [SerializeField] private float _smoothSpeed = 5f;

    private Slider _slider;
    private float _currentValue;
    private float _targetValue;
    private float _littleValue = 0.01f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        _slider.maxValue = _health.Max;
        _currentValue = _health.Value;
        _targetValue = _health.Value;
        _slider.value = _currentValue;
    }

    private void Update()
    {
        _currentValue = Mathf.MoveTowards(_currentValue, _targetValue, _smoothSpeed * Time.deltaTime);
        _slider.value = _currentValue;

        if (Mathf.Abs(_currentValue - _targetValue) < _littleValue)
        {
            _currentValue = _targetValue;
        }
    }

    protected override void OnChanged()
    {
        _targetValue = _health.Value;
    }
}