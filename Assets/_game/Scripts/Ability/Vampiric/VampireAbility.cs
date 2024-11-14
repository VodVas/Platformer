using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(ObjectsInRoundFinder))]
public class VampireAbility : MonoBehaviour
{
    private const string Vamp = "Vamp";

    [SerializeField] private float _damage = 3;

    [field: SerializeField] public float Radius { get; private set; } = 10f;

    private bool _canUse = true;
    private Health _playerHealth;
    private WaitForSeconds _wait;
    private ObjectsInRoundFinder _objectsFinder;

    public float Duration { get; private set; } = 6f;
    public float Cooldown { get; private set; } = 4f;
    public bool IsActive { get; private set; } = false;

    private void Awake()
    {
        _wait = new WaitForSeconds(Cooldown);

        _playerHealth = GetComponent<Health>();
        _objectsFinder = GetComponent<ObjectsInRoundFinder>();
    }

    private void Update()
    {
        if (_canUse == true && Input.GetButtonDown(Vamp))
        {
            Activate();
        }
    }

    public void Activate()
    {

        if (IsActive == false)
        {
            IsActive = true;
            _canUse = false;

            StartCoroutine(Apply());
        }
    }

    private IEnumerator Apply()
    {
        float timer = 0f;

        while (timer < Duration)
        {
            Enemy nearestEnemy = _objectsFinder.FindNearestObject<Enemy>(Radius);

            if (nearestEnemy != null)
            {
                if (nearestEnemy.TryGetComponent(out Enemy enemy))
                {
                    enemy.ApplyDamage(_damage * Time.deltaTime);

                    _playerHealth.Increase(_damage * Time.deltaTime);
                }
            }

            timer += Time.deltaTime;

            yield return null;
        }

        IsActive = false;

        yield return _wait;

        _canUse = true;
    }
}