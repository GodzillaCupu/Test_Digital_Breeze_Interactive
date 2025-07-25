using System.Collections;
using UnityEngine;

public class DieState : BaseState
{
    GameObject targetObject;
    AnimationsController _animation;
    float _fadeDuration = 3;

    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the die state
        targetObject = manager.gameObject;
        _animation = targetObject.GetComponent<IController>().Animation;

        DisableObject(targetObject);
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the die state
        _animation.PlayAnimations("Die");
    }

    public override void OnFixedUpdate(StateManager manager)
    {
    }

    public override void OnCollisionEnter(StateManager manager, Collision2D other)
    {
        // Logic for handling collisions in the die state
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the die state
        targetObject = null;
        _animation = null;
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
