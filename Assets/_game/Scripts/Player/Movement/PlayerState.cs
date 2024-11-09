public abstract class PlayerState
{
    protected PlayerStateMachine _player;

    public PlayerState(PlayerStateMachine playerController)
    {
        _player = playerController;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}