using UnityEngine;

public class JumpState : BaseState
{
    PlayerController controller;
    AnimationsController animation;
    Rigidbody2D rb;

    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the jump state
        controller = manager.gameObject.GetComponent<PlayerController>();
        animation = controller.Animation;
        rb = controller.Rigidbody;

        if (controller.CanJump) Jump();
    }

    private void Jump()
    {
        controller.CanJump = false;
        animation.PlayAnimations("Jumping");
        rb.AddForce(rb.transform.up * controller.JumpHeight, ForceMode2D.Impulse);
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the jump state

    }

    public override void OnFixedUpdate(StateManager manager)
    {
        // Logic for Fixed Updating the jump state
    }

    public override void OnCollisionEnter(Collision2D other)
    {
        // Logic for handling collisions in the jump state
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the jump state

    }
}