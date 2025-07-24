using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private BaseState currentState;

    public BaseState CurrentState { get => currentState; set => currentState = value; }

    public DieState _dieState = new DieState();
    public RunState _runState = new RunState();
    public IdleState _idleState = new IdleState();
    public HurtState _hurtState = new HurtState();
    public JumpState _jumpState = new JumpState();
    public AttackState _attackState = new AttackState();

    private void Start()
    {
        currentState = _idleState;
        currentState.OnEnter(this);
    }

    private void Update()
    {
        if (currentState == null) return;

        currentState.OnUpdate(this);
    }
    private void FixedUpdate()
    {
        if (currentState == null) return;
        currentState.OnFixedUpdate(this);
    }

    private void OCollisionEnter2D(Collision2D collision)
    {
        if (currentState == null) return;
        currentState.OnCollisionEnter(collision);
    }

    public void ChangeState(BaseState newState)
    {
        BaseState previousState = currentState;
        BaseState NextState = newState;

        if (previousState == null) return;

        previousState.OnExit(this);

        currentState = NextState;
        currentState.OnEnter(this);
    }
}
