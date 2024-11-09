using UnityEngine;

public class Coin : CollectibleItem
{
    [field: SerializeField] public int Amount { get; private set; } = 1;

    public bool IsCollected { get; private set; } = false;

    public void Collect()
    {
        if (!IsCollected)
        {
            IsCollected = true;
        }
    }

    public void Reset()
    {
        IsCollected = false;
    }
}

//public class Coin : CollectibleItem
//{
//    public bool IsCollected { get; private set; } = false;

//    public override void Collect()
//    {
//        if (!IsCollected)
//        {
//            IsCollected = true;
//        }
//    }

//    public void Reset()
//    {
//        IsCollected = false;
//    }
//}