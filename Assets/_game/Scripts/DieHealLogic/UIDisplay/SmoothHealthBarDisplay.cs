using System.Collections;
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
    private Coroutine _filling;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        _slider.maxValue = _health.Max;
        _currentValue = _health.Value;
        _targetValue = _health.Value;
        _slider.value = _currentValue;
    }

    private new void OnEnable()
    {
        _health.Changed += OnHealthChanged;
    }

    private new void OnDisable()
    {
        _health.Changed -= OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        _targetValue = _health.Value;

        if (_filling != null)
        {
            StopCoroutine(_filling);
        }

        _filling = StartCoroutine(Filling());
    }

    private IEnumerator Filling()
    {
        while (Mathf.Abs(_currentValue - _targetValue) > _littleValue)
        {
            _currentValue = Mathf.MoveTowards(_currentValue, _targetValue, _smoothSpeed * Time.deltaTime);
            _slider.value = _currentValue;

            yield return null;
        }

        _currentValue = _targetValue;
        _slider.value = _currentValue;
    }
}