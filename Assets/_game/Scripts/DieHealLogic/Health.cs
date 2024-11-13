using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _max = 100;
    public float Max => _max;

    public float Value { get; private set; }

    public event Action HealthChange;

    private void Start()
    {
        Value = _max;
        HealthChange?.Invoke();
    }

    public void Increase(int healAmount)
    {
        Value = Mathf.Min(Value + healAmount, _max);
        HealthChange?.Invoke();
    }

    public void Decrease(int damage)
    {
        Value = Mathf.Max(Value - damage, 0);
        HealthChange?.Invoke();
    }
}