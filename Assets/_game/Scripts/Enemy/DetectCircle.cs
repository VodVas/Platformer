using System;
using UnityEngine;

public class DetectCircle : MonoBehaviour
{
    public event Action<Transform> TriggerEnterEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            TriggerEnterEvent?.Invoke(player.transform);
        }
    }
}