using UnityEngine;

public class WalkState : PlayerState
{
    private InputReader _inputReader;
    private Move _move;

    public WalkState(PlayerStateMachine playerController, Move move, InputReader inputReader) : base(playerController)
    {
        _move = move;
        _inputReader = inputReader;
    }

    public override void Enter()
    {
        Player.Animator.SetBool(InputReader.IsWalking, true);
    }

    public override void Update()
    {
        _move.DoMove(Player.WalkSpeed);

        if (_inputReader.HorizontalMove == 0)
        {
            Player.ChangeState(Player.IdleState);
        }
        else if (_inputReader.IsJump)
        {
            Player.ChangeState(Player.JumpState);
        }
        else if (_inputReader.IsRun)
        {
            Player.ChangeState(Player.RunState);
        }
    }

    public override void Exit()
    {
        Player.Animator.SetBool(InputReader.IsWalking, false);
    }
}