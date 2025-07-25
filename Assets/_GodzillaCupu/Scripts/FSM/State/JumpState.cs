using UnityEngine;

public class JumpState : BaseState
{
    InputHandler input;
    IController controller;
    AnimationsController animation;
    Rigidbody2D rb;

    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the jump state
        input = manager.gameObject.GetComponent<InputHandler>();
        controller = manager.gameObject.GetComponent<IController>();

        animation = controller.Animation;
        rb = controller.Rigidbody;
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the jump state
        if (input.CanJump)
            Jump();

    }

    public override void OnFixedUpdate(StateManager manager)
    {
        // Logic for Fixed Updating the jump state
    }

    public override void OnCollisionEnter(StateManager manager, Collision2D other)
    {
        // Logic for handling collisions in the jump state

    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the jump state
        input = null;
        controller = null;
        animation = null;
        rb = null;
    }

    private void Jump()
    {
        input.CanJump = false;
        animation.PlayAnimations("Jumping");
        rb.AddForce(rb.transform.up * input.JumpHeight, ForceMode2D.Impulse);
    }
}