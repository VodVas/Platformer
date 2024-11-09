using UnityEngine;

public class RunState : PlayerState
{
    private const string Horizontal = "Horizontal";
    private const string IsRunning = "IsRunning";
    private const string Jump = "Jump";
    private const string Run = "Run";

    private Move _move;

    public RunState(PlayerStateMachine playerController, Move move) : base(playerController) 
    {
        _move = move;
    }

    public override void Enter()
    {
        _player.Animator.SetBool(IsRunning, true);
    }

    public override void Update()
    {
        _move.DoMove(_player.RunSpeed);

        if (Input.GetAxisRaw(Horizontal) == 0)
        {
            _player.ChangeState(_player.IdleState);
        }
        else if (Input.GetButtonDown(Jump))
        {
            _player.ChangeState(_player.JumpState);
        }
        else if (!Input.GetButton(Run))
        {
            _player.ChangeState(_player.WalkState);
        }
    }

    public override void Exit()
    {
        _player.Animator.SetBool(IsRunning, false);
    }
}