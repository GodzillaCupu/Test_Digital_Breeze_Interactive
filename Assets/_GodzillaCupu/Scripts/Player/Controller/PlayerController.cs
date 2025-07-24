using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : InputHandler
{
    [SerializeField] private AnimationsController animations;
    [SerializeField] private Rigidbody2D rb;

    public StateManager stateManager;

    public AnimationsController Animations { get => animations; set => animations = value; }
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
            stateManager.ChangeState(stateManager._idleState);
            return;
        }
        stateManager.ChangeState(stateManager._runState);
    }

    private void CheckCanJumping()
    {
        if (IsJumping())
            stateManager.ChangeState(stateManager._jumpState);
    }

    private bool CheckDead()
    {
        bool _isDead = Health == 0 ? true : false;
        if (_isDead)
            stateManager.ChangeState(stateManager._dieState);

        return _isDead;
    }
}
