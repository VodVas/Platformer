using UnityEngine;

public class AidKit : CollectibleItem
{
    [field: SerializeField] public int HealAmount { get; private set; } = 10;
}