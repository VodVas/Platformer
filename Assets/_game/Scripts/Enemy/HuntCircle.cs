using System;
using UnityEngine;

public class HuntCircle : MonoBehaviour
{
    public event Action TriggerExitEvent;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            TriggerExitEvent?.Invoke();
        }
    }
}