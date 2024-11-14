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
        _health.AlmostDied += Die;
    }

    private void OnDisable()
    {
        _health.AlmostDied -= Die;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}