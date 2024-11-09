using UnityEngine;

public class HuntCircle : MonoBehaviour
{
    [SerializeField] private EnemyAI _enemyAI;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player _))
        {
            _enemyAI.ClearPlayer();
        }
    }
}