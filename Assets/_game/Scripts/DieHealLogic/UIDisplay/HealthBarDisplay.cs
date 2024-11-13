using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        _slider.maxValue = _health.Max;
        _slider.value = _health.Value;
    }

    private void OnEnable()
    {
        _health.HealthChange += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _health.HealthChange -= UpdateHealthBar;
    }

    private void UpdateHealthBar()
    {
        _slider.value = _health.Value;
    }
}