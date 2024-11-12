using System;
using UnityEngine;

public class Coin : CollectibleItem
{
    [field: SerializeField] public int Amount { get; private set; } = 1;

    public event Action<Coin> CoinCollected;

    public override void Collect()
    {
        CoinCollected?.Invoke(this);
    }
}