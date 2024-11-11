using UnityEngine;

public class Attacker : MonoBehaviour
{
    private Animator _animator;
    private InputReader _inputReader;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        if (_inputReader.IsMouseButtonDown)
        {
            StartAttack();
        }
    }

    private void StartAttack()
    {
        _animator.SetBool(InputReader.IsFight, true);
    }
}