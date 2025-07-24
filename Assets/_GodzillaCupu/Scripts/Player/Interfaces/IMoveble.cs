using UnityEngine;

public interface IMovable
{
    bool CanMove { get; set; }
    float Speed { get; set; }
    Vector2 GetMovementInput();
    bool IsJumping();
}
