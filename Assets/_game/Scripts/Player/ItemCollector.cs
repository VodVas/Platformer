using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class ItemCollector : MonoBehaviour
{
    private Health _health;
    private int _coinCount = 0;

    public event Action<CollectibleItem> ItemCollect;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CollectibleItem item))
        {
            item.Collect();

            ItemCollect?.Invoke(item);

            if (item is Coin coin)
            {
                _coinCount += coin.Amount;
            }
            else if (item is AidKit aidKit)
            {
                _health.Increase(aidKit.HealAmount);
            }
        }
    }
}