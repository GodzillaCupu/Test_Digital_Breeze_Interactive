using UnityEngine;

public class IdleState : BaseState
{
    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the idle state
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the idle state
    }

    public override void OnFixedUpdate(StateManager manager)
    {

    }

    public override void OnCollisionEnter(Collision2D other)
    {
        // Logic for handling collisions in the idle state
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the idle state
    }
}