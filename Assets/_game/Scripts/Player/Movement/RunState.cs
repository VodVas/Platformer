public class RunState : PlayerState
{
    private Move _move;
    private InputReader _inputReader;

    public RunState(PlayerStateMachine playerController, Move move, InputReader inputReader) : base(playerController) 
    {
        _move = move;
        _inputReader = inputReader;
    }

    public override void Enter()
    {
        Player.Animator.SetBool(InputReader.IsRunning, true);
    }

    public override void Update()
    {
        _move.DoMove(Player.RunSpeed);

        if (_inputReader.HorizontalMove == 0)
        {
            Player.ChangeState(Player.IdleState);
        }
        else if (_inputReader.IsJump)
        {
            Player.ChangeState(Player.JumpState);
        }
        else if (_inputReader.IsRun == false)
        {
            Player.ChangeState(Player.WalkState);
        }
    }

    public override void Exit()
    {
        Player.Animator.SetBool(InputReader.IsRunning, false);
    }
}