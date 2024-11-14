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

    private void Update()
    {
        if (_vampireAbility.IsActive)
        {
            _currentValue += Time.deltaTime / _vampireAbility.Duration;

            if (_currentValue > _maxValue)
            {
                _currentValue = _maxValue;
            }
        }
        else
        {
            _currentValue -= Time.deltaTime / _vampireAbility.Cooldown;

            if (_currentValue < _minValue)
            {
                _currentValue = _minValue;
            }
        }

        _slider.value = _currentValue;
    }
}