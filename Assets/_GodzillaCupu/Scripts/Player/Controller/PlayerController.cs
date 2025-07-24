using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : InputHandler, BaseController
{
    [SerializeField] private AnimationsController _animation;
    [SerializeField] private StateManager stateManager;
    [SerializeField] private Rigidbody2D rb;

    public StateManager StateManager { get => stateManager; set => stateManager = value; }

    public AnimationsController Animation { get => _animation; set => _animation = value; }
    public Rigidbody2D Rigidbody { get => rb; set => rb = value; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializedInputActions();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanMove) return;

        CheckCanWalk();
        CheckCanJumping();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enviroment")
            CanJump = true;
    }

    private void OnEnable()
    {
        base.EnableInput();
    }

    private void OnDisable()
    {
        base.DisableInput();
    }

    private void CheckCanWalk()
    {
        if (GetMovementInput() == Vector2.zero)
        {
            StateManager.ChangeState(StateManager._idleState);
            return;
        }
        StateManager.ChangeState(StateManager._runState);
    }

    private void CheckCanJumping()
    {
        if (IsJumping())
            StateManager.ChangeState(StateManager._jumpState);
    }

    private bool CheckDead()
    {
        bool _isDead = Health == 0 ? true : false;
        if (_isDead)
            StateManager.ChangeState(StateManager._dieState);

        return _isDead;
    }
}
