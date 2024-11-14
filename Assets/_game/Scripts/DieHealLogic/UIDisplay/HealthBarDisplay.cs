using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarDisplay : HealthDisplayBase
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        _slider.maxValue = _health.Max;
        _slider.value = _health.Value;
    }

    protected override void OnChanged()
    {
        _slider.value = _health.Value;
    }
}