using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    public int CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = _maxHealth;
    }

    public void Increase(int healAmount)
    {
        CurrentHealth = Mathf.Min(CurrentHealth + healAmount, _maxHealth);
    }

    public void Decrease(int damage)
    {
        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);
    }
}