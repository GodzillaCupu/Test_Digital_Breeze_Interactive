using System.ComponentModel;
using UnityEngine;

public abstract class BaseState
{
    public abstract void OnEnter(StateManager manager);

    public abstract void OnUpdate(StateManager manager);

    public abstract void OnFixedUpdate(StateManager manager);

    public abstract void OnCollisionEnter(Collision2D other);

    public abstract void OnExit(StateManager manager);
}
