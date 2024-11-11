using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max = 100;

    public int Value { get; private set; }

    private void Start()
    {
        Value = _max;
    }

    public void Increase(int healAmount)
    {
        Value = Mathf.Min(Value + healAmount, _max);
    }

    public void Decrease(int damage)
    {
        Value = Mathf.Max(Value - damage, 0);
    }
}