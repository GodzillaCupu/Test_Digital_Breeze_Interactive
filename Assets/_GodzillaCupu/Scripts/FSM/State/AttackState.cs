using UnityEngine;

public class AttackState : BaseState
{
    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the attack state
        
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the attack state
    }

    public override void OnFixedUpdate(StateManager manager)
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionEnter(Collision2D other)
    {
        // Logic for handling collisions in the attack state
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the attack state
    }


}