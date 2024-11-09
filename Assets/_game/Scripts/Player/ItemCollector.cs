using System;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private Health _health;
    private int _coinCount = 0;

    public event Action<Coin> CoinCollect;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CollectibleItem item))
        {
            if (item is Coin coin && !coin.IsCollected)
            {
                CoinCollect?.Invoke(coin);

                _coinCount += coin.Amount;

                coin.Collect();
            }
            else if (item is AidKit aidKit)
            {
                if (_health != null)
                {
                    _health.Increase(aidKit.HealAmount);

                    Destroy(item.gameObject);
                }
            }
        }
    }
}