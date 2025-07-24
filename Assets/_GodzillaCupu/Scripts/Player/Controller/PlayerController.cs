using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : InputHandler, IController, IAttack
{
    [SerializeField] private AnimationsController _animation;
    [SerializeField] private StateManager stateManager;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Slider healthBar;

    [Header("Attack")]
    [SerializeField] private bool canAttack = true;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBulletPostions;

    public StateManager StateManager { get => stateManager; set => stateManager = value; }
    public AnimationsController Animation { get => _animation; set => _animation = value; }
    public Slider HealthBar { get => healthBar; set => healthBar = value; }
    public Rigidbody2D Rigidbody { get => rb; set => rb = value; }
    public bool CanAttack { get => canAttack; set => canAttack = value; }
    public GameObject Bullet { get => bullet; set => bullet = value; }
    public Transform SpawnBulletPostions { get => spawnBulletPostions; set => spawnBulletPostions = value; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializedInputActions();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanMove) return;

        if (stateManager.CurrentState == StateManager._dieState) return;

        CheckCanWalk();
        CheckCanJumping();
        OnAttack();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enviroment")
            CanJump = true;

        if (collision.gameObject.tag == "Bullet")
        {
            GameObject _bullet = collision.gameObject;
            UpdateHealth(_bullet.GetComponent<BaseWeapon>().Damage);
            if (CheckDead()) return;
            stateManager.ChangeState(stateManager._hurtState);
        }
    }

    private void OnEnable()
    {
        base.EnableInput();
    }

    private void OnDisable()
    {
        base.DisableInput();
    }

    private void CheckCanWalk()
    {
        if (GetMovementInput() == Vector2.zero)
        {
            StateManager.ChangeState(StateManager._idleState);
            return;
        }
        StateManager.ChangeState(StateManager._runState);
    }

    private void CheckCanJumping()
    {
        if (IsJumping())
            StateManager.ChangeState(StateManager._jumpState);
    }

    private bool CheckDead()
    {
        bool _isDead = Health == 0 ? true : false;
        if (_isDead)
            StateManager.ChangeState(StateManager._dieState);

        return _isDead;
    }

    private float UpdateHealth(float _hp)
    {
        Health -= _hp;
        HealthBar.value = Health / 100;

        return Health;
    }

    public void OnAttack()
    {
        if (IsAttacking())
            StateManager.ChangeState(StateManager._attackState);
    }
}
