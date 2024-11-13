using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthTextDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _health.HealthChange += UpdateHealthText;
    }

    private void OnDisable()
    {
        _health.HealthChange -= UpdateHealthText;
    }

    private void UpdateHealthText()
    {
        _text.text = $"{_health.Value}/{_health.Max}";
    }
}