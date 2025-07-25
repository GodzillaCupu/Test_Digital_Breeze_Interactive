using UnityEngine;

public interface IMovable
{
    bool CanMove { get; set; }
    float Speed { get; set; }
    float JumpHeight { get; set; }
    bool CanJump { get; set; }
    bool IsJumping();
    Vector2 GetMovementInput();
}
