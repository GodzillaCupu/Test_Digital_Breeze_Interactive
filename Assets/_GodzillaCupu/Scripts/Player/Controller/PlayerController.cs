using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : InputHandler
{
    [SerializeField] private AnimationsController animations;
    [SerializeField] private bool canMove;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;


    public override bool CanMove { get => canMove; set => canMove = value; }
    public override float Speed
    {
        get => speed;
        set => speed = value;
    }
    public Rigidbody2D Rigidbody
    {
        get => rb;
        set => rb = value;
    }

    public AnimationsController Animations
    {
        get => animations;
        set => animations = value;
    }

    public StateManager stateManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializedInputActions();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetMovementInput() != Vector2.zero)
            stateManager.ChangeState(stateManager._runState);
    }

    private void OnEnable()
    {
        base.EnableInput();
    }
    
    private void OnDisable()
    {
        base.DisableInput();
    }
}
