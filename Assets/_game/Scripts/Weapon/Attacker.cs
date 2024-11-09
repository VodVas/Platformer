using UnityEngine;

public class Attacker : MonoBehaviour
{
    private const string IsFight = "IsFight";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartAttack();
        }
    }

    private void StartAttack()
    {
        _animator.SetBool(IsFight, true);
    }
}