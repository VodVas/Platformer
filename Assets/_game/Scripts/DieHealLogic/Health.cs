using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _max = 100;
    private float _minValueHealth = 1;
    
    public event Action Changed;
    public event Action AlmostDied;

    public float Max => _max;
    public float Value { get; private set; }

    private void Start()
    {
        Value = _max;
        Changed?.Invoke();
    }

    private void Update()
    {
        if (Value < _minValueHealth)
        {
            AlmostDied?.Invoke();
        }
    }

    public void Increase(int healAmount)
    {
        Value = Mathf.Min(Value + healAmount, _max);
        Changed?.Invoke();
    }

    public void Decrease(int damage)
    {
        Value = Mathf.Max(Value - damage, 0);
        Changed?.Invoke();
    }

    public void Decrease(float damage)
    {
        Value = Mathf.Max(Value - damage, 0);
        Changed?.Invoke();
    }

    public void Increase(float healAmount)
    {
        Value = Mathf.Min(Value + healAmount, _max);
        Changed?.Invoke();
    }
}
