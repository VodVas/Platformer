using UnityEngine;

public class Coin : CollectibleItem
{
    [field: SerializeField] public int Amount { get; private set; } = 1;
}