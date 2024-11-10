using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max = 100;

    public int Current { get; private set; }

    private void Start()
    {
        Current = _max;
    }

    public void Increase(int healAmount)
    {
        Current = Mathf.Min(Current + healAmount, _max);
    }

    public void Decrease(int damage)
    {
        Current = Mathf.Max(Current - damage, 0);
    }
}