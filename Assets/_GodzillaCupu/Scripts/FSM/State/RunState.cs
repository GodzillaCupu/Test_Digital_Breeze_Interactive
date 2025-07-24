using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class RunState : BaseState
{
    PlayerController controller;
    AnimationsController animation;
    Rigidbody2D rb;
    SpriteRenderer renderer;

    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the run state
        controller = manager.gameObject.GetComponent<PlayerController>();
        animation = controller.Animations;
        rb = controller.Rigidbody;

        renderer = animation.gameObject.GetComponent<SpriteRenderer>();
        Walk();
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the run state

    }

    public override void OnFixedUpdate(StateManager manager)
    {
        // Logic for fixed updating the run state
    }

    private void Walk()
    {
        switch (controller.GetMovementInput().x)
        {
            case 0:
                controller.stateManager.ChangeState(controller.stateManager._idleState);
                break;

            case 1:
                renderer.flipX = false;
                rb.MovePosition(rb.position + new Vector2(1 * controller.Speed, rb.position.y - rb.gravityScale) * Time.deltaTime);
                animation.PlayAnimations("Running");
                break;

            case -1:
                renderer.flipX = true;
                rb.MovePosition(rb.position + new Vector2(-1 * controller.Speed, rb.position.y - rb.gravityScale) * Time.deltaTime);
                animation.PlayAnimations("Running");
                break;

            default:
                controller.stateManager.ChangeState(controller.stateManager._idleState);
                break;
        }
    }

    public override void OnCollisionEnter(Collision2D other)
    {
        // Logic for handling collisions in the run state
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the run state
    }
}