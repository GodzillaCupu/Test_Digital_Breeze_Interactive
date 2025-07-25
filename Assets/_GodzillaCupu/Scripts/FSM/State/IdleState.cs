using UnityEngine;

public class IdleState : BaseState
{
    IController controller;
    AnimationsController animations;

    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the idle state
        controller = manager.gameObject.GetComponent<IController>();
        animations = controller.Animation;
        animations.PlayAnimations("Idle");
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the idle state
    }

    public override void OnFixedUpdate(StateManager manager)
    {
    }
    public override void OnCollisionEnter(StateManager manager, Collision2D other)
    {
        // Logic for handling collisions in the idle state
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the idle state
        controller = null;
        animations = null;
    }
}