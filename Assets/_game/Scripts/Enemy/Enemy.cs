using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public float ApplyDamage(float damage)
    {
        _health.Decrease(damage);

        return damage;
    }
}