using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour, IController, IAttack
{
    [SerializeField] private AnimationsController animations;
    [SerializeField] private StateManager stateManager;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBulletPostions;
    [SerializeField] private bool canAttack = true;
    [SerializeField] private bool isDie = false;

    [SerializeField] private float intialInterval = 2f;
    [SerializeField] private float delayInterval = 3f;

    public bool CanAttack { get => canAttack; set => canAttack = value; }
    public AnimationsController Animation { get => animations; set => animations = value; }
    public StateManager StateManager { get => stateManager; set => stateManager = value; }
    public Rigidbody2D Rigidbody { get => rb; set => rb = value; }
    public GameObject Bullet { get => bullet; set => bullet = value; }
    public Transform SpawnBulletPostions { get => spawnBulletPostions; set => spawnBulletPostions = value; }
    [SerializeField] private UnityEvent triggerEvent;

    private void Start()
    {
        InvokeRepeating("OnAttack", intialInterval, delayInterval);
    }

    void Update()
    {
        if (isDie) return;
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Bullet") return;
        isDie = true;
        stateManager.ChangeState(stateManager._dieState);
    }

    public void OnAttack()
    {
        if (isDie)
        {
            triggerEvent.Invoke();
            return;
        }

        CanAttack = true;
        StateManager.ChangeState(StateManager._attackState);
        Debug.Log("Kunai Enemy");
    }
}
