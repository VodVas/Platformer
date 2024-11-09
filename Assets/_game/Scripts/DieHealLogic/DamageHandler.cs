using UnityEngine;

[RequireComponent(typeof(DieHandler))]
[RequireComponent(typeof(Health))]
public class DamageHandler : MonoBehaviour
{
    private Health _healthHandler;
    private DieHandler _dieHandler;

    private void Awake()
    {
        _healthHandler = GetComponent<Health>();
        _dieHandler = GetComponent<DieHandler>();
    }

    public void TakeDamage(int damage)
    {
        _healthHandler.Decrease(damage);

        if (_healthHandler.CurrentHealth <= 0)
        {
            _dieHandler.Die();
        }
    }
}