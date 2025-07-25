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
        if(currentState == null)
            currentState = _idleState;

        currentState.OnEnter(this);
    }

    private void Update()
    {
        if (currentState == null) return;
        Debug.Log($"Current State is {currentState}");
        currentState.OnUpdate(this);
    }

    private void FixedUpdate()
    {
        if (currentState == null) return;
        currentState.OnFixedUpdate(this);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (currentState == null) return;
        currentState.OnCollisionEnter(this, other);
    }

    public void ChangeState(BaseState newState)
    {
        BaseState previousState = currentState;
        BaseState NextState = newState;

        if (previousState == null) return;
        if (previousState == NextState) return;
        
        previousState.OnExit(this);
        NextState.OnEnter(this);

        currentState = NextState;
    }
}
