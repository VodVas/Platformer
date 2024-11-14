using UnityEngine;

public abstract class HealthDisplayBase : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected virtual void OnEnable()
    {
        _health.Changed += OnChanged;
    }

    protected virtual void OnDisable()
    {
        _health.Changed -= OnChanged;
    }

    protected abstract void OnChanged();
}