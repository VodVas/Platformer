using UnityEngine;

[RequireComponent(typeof(Health))]
public class DieHandler : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.AlmostDead += Die;
    }

    private void OnDisable()
    {
        _health.AlmostDead -= Die;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}