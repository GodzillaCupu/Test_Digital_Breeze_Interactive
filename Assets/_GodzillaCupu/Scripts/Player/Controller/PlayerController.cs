using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
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

    [SerializeField] private UnityEvent triggerEvent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializedInputActions();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanMove) return;

        CheckCanWalk();
        CheckCanJumping();
        OnAttack();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject _bullet = collision.gameObject;
            UpdateHealth(_bullet.GetComponent<BaseWeapon>().Damage);
            stateManager.ChangeState(stateManager._hurtState);
            if (CheckDead()) return;
        }

        if (collision.gameObject.tag == "Enviroment")
        {
            CanJump = true;
            CheckCanWalk();
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

        Vector2 dir = GetMovementInput();
        if (dir.x != 0)
            stateManager.ChangeState(stateManager._runState);
        else
            SetIdle();
    }

    private void SetIdle()
    {
        stateManager.ChangeState(stateManager._idleState);
    }

    private void CheckCanJumping()
    {
        if (IsJumping() && CanJump)
            StateManager.ChangeState(StateManager._jumpState);
    }

    private bool CheckDead()
    {
        bool _isDead = Health == 0 ? true : false;
        if (_isDead)
        {
            StateManager.ChangeState(StateManager._dieState);
            triggerEvent.Invoke();
            CanMove = false;
        }

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
