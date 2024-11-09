using UnityEngine;

public class DetectCircle : MonoBehaviour
{
    [SerializeField] private EnemyAI _enemyAI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player _))
        {
            _enemyAI.SetPlayer(other.transform);
        }
    }
}