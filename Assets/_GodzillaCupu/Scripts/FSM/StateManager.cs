using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] BaseState currentState;
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
