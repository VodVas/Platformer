using UnityEngine;

public class JumpState : PlayerState
{
    private const string Jump = "Jump";
    private const string Horizontal = "Horizontal";

    private Utility _utility;
    private Jump _jump;
    private Move _move;

    public JumpState(PlayerStateMachine playerController, Utility utility, Jump jump, Move move) : base(playerController)
    {
        _utility = utility;
        _jump = jump;
        _move = move;
    }

    public override void Enter()
    {
        _player.Animator.SetTrigger(Jump);
        _jump.DoJump(_player.JumpForce);
    }

    public override void Update()
    {
        _move.DoMove(_player.WalkSpeed);

        if (_utility.IsGrounded())
        {
            if (Input.GetAxisRaw(Horizontal) != 0)
            {
                _player.ChangeState(_player.WalkState);
            }
            else
            {
                _player.ChangeState(_player.IdleState);
            }
        }
    }

    public override void Exit() { }
}