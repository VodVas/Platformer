using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _max = 100;

    public event Action Changed;

    public float Max => _max;
    public float Value { get; private set; }

    private void Start()
    {
        Value = _max;
        Changed?.Invoke();
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
}