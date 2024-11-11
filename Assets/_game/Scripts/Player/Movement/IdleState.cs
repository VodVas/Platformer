public class IdleState : PlayerState
{
    private InputReader _inputReader;

    public IdleState(PlayerStateMachine playerController, InputReader inputReader) : base(playerController) { _inputReader = inputReader; }

    public override void Enter()
    {
        Player.Animator.SetBool(InputReader.IsIdle, true);
    }

    public override void Update()
    {
        if (_inputReader.HorizontalMove != 0)
        {
            Player.ChangeState(Player.WalkState);
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
        Player.Animator.SetBool(InputReader.IsIdle, false);
    }
}