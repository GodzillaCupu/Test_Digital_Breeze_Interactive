using UnityEngine;

public class HurtState : BaseState
{
    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the hurt state
        //Set Animation Fade In 
        //Decrease health bar
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the hurt state
    }

    public override void OnCollisionEnter(Collision2D other)
    {
        // Logic for handling collisions in the hurt state
    }

    public override void OnFixedUpdate(StateManager manager)
    {

    }

    public override void OnExit(StateManager manager)
    {
        //SetAnimations Fade Out
    }
}