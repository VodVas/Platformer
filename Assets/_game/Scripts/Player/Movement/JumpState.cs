public class JumpState : PlayerState
{
    private GroundDetector _utility;
    private Jump _jump;
    private Move _move;
    private InputReader _inputReader;

    public JumpState(PlayerStateMachine playerController, GroundDetector utility, Jump jump, Move move, InputReader inputReader) : base(playerController)
    {
        _utility = utility;
        _jump = jump;
        _move = move;
        _inputReader = inputReader;
    }

    public override void Enter()
    {
        Player.Animator.SetTrigger(InputReader.Jump);
        _jump.DoJump(Player.JumpForce);
    }

    public override void Update()
    {
        _move.DoMove(Player.WalkSpeed);

        if (_utility.IsGrounded())
        {
            if (_inputReader.HorizontalMove != 0)
            {
                Player.ChangeState(Player.WalkState);
            }
            else
            {
                Player.ChangeState(Player.IdleState);
            }
        }
    }
}