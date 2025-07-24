using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputHandler : MonoBehaviour,IMovable
{
    public InputActionAsset inputMap;
    private InputAction moveActions{ get; set; }
    private InputAction jumpActions{ get; set; }

    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private bool canJump = false;
    [SerializeField] private bool canMove = true;

    [Header("Input")]
    [SerializeField] private Vector2 moveAmmout;
    [SerializeField] private bool isJumpingPressed;

    public virtual float Health { get => health; set => speed = health; }
    public virtual float Speed { get => speed; set => speed = value; }
    public virtual float JumpHeight { get => jumpHeight; set => jumpHeight = value; }
    public virtual bool CanJump { get => canJump; set =>canJump = value ; }
    public virtual bool CanMove { get => canMove; set =>canMove = value ; }

    public void EnableInput()
    {
        inputMap.FindActionMap("Player").Enable();
    }

    public void DisableInput()
    {
        inputMap.FindActionMap("Player").Disable();
    }

    public void InitializedInputActions()
    {
        moveActions = InputSystem.actions.FindAction("Move");
        jumpActions = InputSystem.actions.FindAction("Jump");
    }

    public Vector2 GetMovementInput()
    {
        moveAmmout = moveActions.ReadValue<Vector2>();
        return moveAmmout;
    }

    public bool IsJumping()
    {
        // isJumpingPressed = jumpActions.WasPerformedThisFrame();
        isJumpingPressed = jumpActions.WasPressedThisFrame() || jumpActions.WasPerformedThisFrame() ? true : false;
        return isJumpingPressed;
    }
}
