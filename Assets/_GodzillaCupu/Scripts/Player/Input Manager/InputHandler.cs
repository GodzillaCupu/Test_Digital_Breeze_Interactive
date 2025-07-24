using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputHandler : MonoBehaviour,IMovable
{
    public InputActionAsset inputMap;
    private InputAction moveActions{ get; set; }
    public InputAction jumpActions{ get; set; }
    [SerializeField] private Vector2 moveAmmout;
    [SerializeField] private bool isJumpingPressed;

    public virtual float Speed { get; set; }
    public virtual bool CanMove { get; set; }

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
        isJumpingPressed = jumpActions.WasPerformedThisFrame();
        return isJumpingPressed;
    }
}
