using UnityEngine;

public class RunState : BaseState
{
    PlayerController controller;
    AnimationsController animations;
    Rigidbody2D _rb;
    SpriteRenderer renderer;

    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the run state
        controller = manager.gameObject.GetComponent<PlayerController>();
        animations = controller.Animations;

        renderer = animations.gameObject.GetComponent<SpriteRenderer>();
        _rb = controller.Rigidbody;
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the run state
        switch (controller.GetMovementInput().x)
        {
            case 0:
                controller.stateManager.ChangeState(controller.stateManager._idleState);
                break;

            case 1:
                renderer.flipX = false;
                _rb.MovePosition(_rb.position + new Vector2(1, 0) * controller.Speed * Time.deltaTime);
                animations.PlayAnimations("Running");
                break;

            case -1:
                renderer.flipX = true;
                _rb.MovePosition(_rb.position + new Vector2(-1, 0) * controller.Speed * Time.deltaTime);
                animations.PlayAnimations("Running");
                break;

            default:
                controller.stateManager.ChangeState(controller.stateManager._idleState);
                break;
        }
        
    }

    public override void OnCollisionEnter(Collision other)
    {
        // Logic for handling collisions in the run state
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the run state
    }
}