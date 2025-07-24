using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : InputHandler
{
    [SerializeField] private AnimationsController animations;
    public StateManager stateManager;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canJump = true;
    [SerializeField] public bool isJumping;

    public override bool CanMove { get => canMove; set => canMove = value; }
    public override bool CanJump { get => canJump; set => canJump = value; }
    public override float JumpHeight { get => jumpHeight; set => jumpHeight = value; }
    public override float Speed { get => speed; set => speed = value; }
    public Rigidbody2D Rigidbody { get => rb; set => rb = value; }
    public AnimationsController Animations { get => animations; set => animations = value; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializedInputActions();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        if (GetMovementInput() != Vector2.zero)
            stateManager.ChangeState(stateManager._runState);
        if (IsJumping())
        {
            stateManager.ChangeState(stateManager._jumpState);
        }
    }

    private void OnEnable()
    {
        base.EnableInput();
    }

    private void OnDisable()
    {
        base.DisableInput();
    }
}
