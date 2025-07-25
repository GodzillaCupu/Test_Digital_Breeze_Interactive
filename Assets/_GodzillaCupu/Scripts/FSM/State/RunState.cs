using UnityEngine;

public class RunState : BaseState
{
    InputHandler input;
    IController controller;
    AnimationsController animation;
    Rigidbody2D rb;
    GameObject rendererObject;

    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the run state
        controller = manager.gameObject.GetComponent<IController>();
        input = manager.gameObject.GetComponent<InputHandler>();
        animation = controller.Animation;
        rb = controller.Rigidbody;

        rendererObject = animation.gameObject;
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the run state
        Walking();
    }

    public override void OnFixedUpdate(StateManager manager)
    {
        // Logic for fixed updating the run state
    }

    public override void OnCollisionEnter(StateManager manager, Collision2D other)
    {
        // Logic for handling collisions in the run state
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the run state
        input = null;
        controller = null;
        animation = null;
        rb = null;
        rendererObject = null;

    }

    private void Walking()
    {
        switch (input.GetMovementInput().x)
        {
            case 1:
                rendererObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                rb.MovePosition(rb.position + new Vector2(1 * input.Speed, rb.position.y - rb.gravityScale) * Time.deltaTime);
                break;

            case -1:
                rendererObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                rb.MovePosition(rb.position + new Vector2(-1 * input.Speed, rb.position.y - rb.gravityScale) * Time.deltaTime);
                break;

            default:
                Debug.LogWarning($"Data Not Found {input.GetMovementInput().x}");
                break;
        }
        animation.PlayAnimations("Running");
    }
}