public abstract class PlayerState
{
    protected PlayerStateMachine Player;

    public PlayerState(PlayerStateMachine playerController)
    {
        Player = playerController;
    }

    public abstract void Enter();
    public abstract void Update();
    public virtual void Exit() { }
}