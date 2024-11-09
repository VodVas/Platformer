using UnityEngine;

public class IdleState : PlayerState
{
    private const string Horizontal = "Horizontal";
    private const string IsIdle = "IsIdle";
    private const string Jump = "Jump";
    private const string Run = "Run";

    public IdleState(PlayerStateMachine playerController) : base(playerController) { }

    public override void Enter()
    {
        _player.Animator.SetBool(IsIdle, true);
    }

    public override void Update()
    {
        if (Input.GetAxisRaw(Horizontal) != 0)
        {
            _player.ChangeState(_player.WalkState);
        }
        else if (Input.GetButtonDown(Jump))
        {
            _player.ChangeState(_player.JumpState);
        }
        else if (Input.GetButton(Run))
        {
            _player.ChangeState(_player.RunState);
        }
    }

    public override void Exit()
    {
        _player.Animator.SetBool(IsIdle, false);
    }
}