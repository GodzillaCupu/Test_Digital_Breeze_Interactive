using UnityEngine;

public class IdleState : BaseState
{
    PlayerController controller;
    AnimationsController animations;

    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the idle state
        controller = manager.gameObject.GetComponent<PlayerController>();
        animations = controller.Animations;
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the idle state
        animations.PlayAnimations("Idle");
    }

    public override void OnCollisionEnter(Collision other)
    {
        // Logic for handling collisions in the idle state
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the idle state
    }
}