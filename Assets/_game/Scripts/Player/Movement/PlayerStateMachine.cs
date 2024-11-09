using UnityEngine;

[RequireComponent(typeof(Jump))]
[RequireComponent(typeof(Utility))]
[RequireComponent(typeof(Move))]
public class PlayerStateMachine : MonoBehaviour
{
    private PlayerState _currentState;
    private Utility _utility;
    private Jump _jump;
    private Move _move;

    [field: SerializeField] public float WalkSpeed { get; private set; } = 5f;
    [field: SerializeField] public float RunSpeed { get; private set; } = 10f;
    [field: SerializeField] public float JumpForce { get; private set; } = 3f;

    public IdleState IdleState { get; private set; }
    public WalkState WalkState { get; private set; }
    public RunState RunState { get; private set; }
    public JumpState JumpState { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }
    public Animator Animator { get; private set; }

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        _utility = GetComponent<Utility>();
        _jump = GetComponent<Jump>();
        _move = GetComponent<Move>();

        IdleState = new IdleState(this);
        WalkState = new WalkState(this, _move);
        RunState = new RunState(this, _move);
        JumpState = new JumpState(this, _utility, _jump, _move);

        ChangeState(new IdleState(this));
    }

    private void Update()
    {
        _currentState.Update();
    }

    public void ChangeState(PlayerState newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;
        _currentState.Enter();
    }
}