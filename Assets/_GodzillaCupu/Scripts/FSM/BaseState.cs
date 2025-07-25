using System;
using System.ComponentModel;
using UnityEngine;

[Serializable]
public abstract class BaseState
{
    public abstract void OnEnter(StateManager manager);

    public abstract void OnUpdate(StateManager manager);

    public abstract void OnFixedUpdate(StateManager manager);

    public abstract void OnCollisionEnter(StateManager manager, Collision2D other);

    public abstract void OnExit(StateManager manager);
}
