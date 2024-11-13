using UnityEngine;
using UnityEngine.UI;

public class HealthModifier : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;
    [SerializeField] private int _damageAmount = 10;
    [SerializeField] private int _healAmount = 10;

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(TakeDamage);
        _healButton.onClick.AddListener(Heal);
    }

    private void OnDisable()
    {
        _damageButton.onClick.RemoveListener(TakeDamage);
        _healButton.onClick.RemoveListener(Heal);
    }

    public void TakeDamage()
    {
        _health.Decrease(_damageAmount);
    }

    public void Heal()
    {
        _health.Increase(_healAmount);
    }
}