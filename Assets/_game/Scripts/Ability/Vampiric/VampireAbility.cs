using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(ObjectsInRoundFinder))]
public class VampireAbility : MonoBehaviour
{
    [SerializeField] private float _damage = 3;

    [field: SerializeField] public float Radius { get; private set; } = 10f;

    private bool _canUse = true;
    private Health _playerHealth;
    private WaitForSeconds _wait;
    private ObjectsInRoundFinder _objectsFinder;

    public event Action ActivatedSkill;
    public event Action DeactivatedSkill;

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
        if (_canUse && Input.GetKeyDown(KeyCode.E))
        {
            Activate();
        }
    }

    public void Activate()
    {
        ActivatedSkill?.Invoke();

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
                float damageToDeal = _damage * Time.deltaTime;
                float actualDamage = nearestEnemy.ApplyDamage(damageToDeal);

                _playerHealth.Increase(actualDamage);
            }

            timer += Time.deltaTime;

            yield return null;
        }

        DeactivatedSkill?.Invoke();

        IsActive = false;

        yield return _wait;

        _canUse = true;
    }
}