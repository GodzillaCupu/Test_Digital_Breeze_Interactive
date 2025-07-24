using UnityEngine;

public class DieState : BaseState 
{
    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the die state
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the die state
    }

    public override void OnFixedUpdate(StateManager manager)
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionEnter(Collision2D other)
    {
        // Logic for handling collisions in the die state
        throw new System.NotImplementedException();
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the die state
    }


}
