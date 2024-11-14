using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthTextDisplay : HealthDisplayBase
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    protected override void OnChanged()
    {
        _text.text = $"{_health.Value}/{_health.Max}";
    }
}