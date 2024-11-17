using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VampireAbilitySlider : MonoBehaviour
{
    [SerializeField] private VampireAbility _vampireAbility;

    private Slider _slider;
    private float _currentValue = 0f;
    private float _maxValue = 1f;
    private float _minValue = 0f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _currentValue;
    }

    private void OnEnable()
    {
        _vampireAbility.ActivatedSkill += StartFilling;
        _vampireAbility.DeactivatedSkill += StartUnfilling;
    }

    private void OnDisable()
    {
        _vampireAbility.ActivatedSkill -= StartFilling;
        _vampireAbility.DeactivatedSkill -= StartUnfilling;
    }

    private void StartFilling()
    {
        StartCoroutine(Fill());
    }

    private void StartUnfilling()
    {
        StartCoroutine(UnFill());
    }

    private IEnumerator Fill()
    {
        float fillRate = 1f / _vampireAbility.Duration;

        while (_currentValue < _maxValue)
        {
            _currentValue += fillRate * Time.deltaTime;

            if (_currentValue > _maxValue)
            {
                _currentValue = _maxValue;
            }

            _slider.value = _currentValue;

            yield return null;
        }
    }

    private IEnumerator UnFill()
    {
        float unfillRate = 1f / _vampireAbility.Cooldown;

        while (_currentValue > _minValue)
        {
            _currentValue -= unfillRate * Time.deltaTime;

            if (_currentValue < _minValue)
            {
                _currentValue = _minValue;
            }

            _slider.value = _currentValue;

            yield return null;
        }
    }
}