using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    private const string IsHit = "IsHit";

    [SerializeField] private Animator _animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player _))
        {
            StartAttack();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player _))
        {
            StopAttack();
        }
    }

    private void StartAttack()
    {
        _animator.SetBool(IsHit, true);
    }

    private void StopAttack()
    {
        _animator.SetBool(IsHit, false);
    }
}