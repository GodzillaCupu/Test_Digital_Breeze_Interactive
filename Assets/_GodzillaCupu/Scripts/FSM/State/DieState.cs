using System.Collections;
using UnityEngine;

public class DieState : BaseState
{
    StateManager _manager;
    AnimationsController _animation;
    float _fadeDuration = 3;

    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the die state
        _manager = manager;
        _animation = _manager.gameObject.GetComponent<IController>().Animation;

        _animation.PlayAnimations("Die");
        DisableObject(_manager.gameObject);
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the die state
    }

    public override void OnFixedUpdate(StateManager manager)
    {
    }

    public override void OnCollisionEnter(Collision2D other)
    {
        // Logic for handling collisions in the die state
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the die state
    }

    public void DisableObject(GameObject targetObject)
    {
        Rigidbody2D rb = targetObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;


        BoxCollider2D collider = targetObject.GetComponent<BoxCollider2D>();
        collider.enabled = false;

        LeanTween.alpha(_animation.gameObject, 0, _fadeDuration).setOnComplete(
            () => targetObject.SetActive(false)
        );
    }
}
