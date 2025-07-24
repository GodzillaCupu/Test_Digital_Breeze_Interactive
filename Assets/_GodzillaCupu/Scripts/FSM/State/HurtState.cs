using System.Collections;
using UnityEngine;
public class HurtState : BaseState
{
    SpriteRenderer targetRenderer;
    AnimationsController animation;
    IController controller;
    float fadeDurations = 5f;
    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the hurt state
        controller = manager.gameObject.GetComponent<IController>();
        animation = controller.Animation;

        targetRenderer = animation.gameObject.GetComponent<SpriteRenderer>();

        //Set Animation Fade In 
        LeanTween.value(targetRenderer.gameObject, Color.red, Color.white, fadeDurations).
        setOnComplete(
            () => OnExit(manager)
        );
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

    IEnumerator HurtingAnimations(StateManager manager)
    {
        yield return new WaitForSeconds(fadeDurations);
        OnExit(manager);
    }
}