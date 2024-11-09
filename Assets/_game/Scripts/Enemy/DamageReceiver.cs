using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] private int _inputDamage = 5;

    private DamageHandler _damageHandler;

    private void Awake()
    {
        _damageHandler = GetComponent<DamageHandler>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Weapon _))
        {
            _damageHandler.TakeDamage(_inputDamage);
        }
    }
}