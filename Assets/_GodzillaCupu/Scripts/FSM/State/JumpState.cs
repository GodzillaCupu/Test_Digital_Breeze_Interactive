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
        animation = controller.Animations;
        rb = controller.Rigidbody;
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the jump state
        
        
    }

    public override void OnFixedUpdate(StateManager manager)
    {
        // Logic for Fixed Updating the jump state
        if (controller.IsJumping() && controller.CanJump)
        {
            controller.isJumping = true;
            animation.PlayAnimations("Jumping");
            rb.AddForce(rb.transform.up * controller.JumpHeight, ForceMode2D.Impulse);
        }
    }

    public override void OnCollisionEnter(Collision2D other)
    {
        // Logic for handling collisions in the jump state
        if (other.gameObject.tag == "Enviroment")
        {
            controller.isJumping = false;
            controller.stateManager.ChangeState(controller.stateManager._idleState);
        }
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the jump state

    }
}