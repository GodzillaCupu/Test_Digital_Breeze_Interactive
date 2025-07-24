using System.Collections;
using UnityEngine;

public class DieState : BaseState
{
    StateManager _manager;
    AnimationsController _animation;
    float _fadeDuration;

    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the die state
        _manager = manager;
        _animation = _manager.gameObject.GetComponent<BaseController>().Animation;

        _animation.PlayAnimations("Die");
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

    IEnumerator CountDownFadeOut()
    {
        yield return new WaitForSeconds(_fadeDuration);
    }
}
