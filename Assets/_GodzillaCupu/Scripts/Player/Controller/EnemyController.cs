using UnityEngine;

public class EnemyController : MonoBehaviour, BaseController
{
    [SerializeField] private AnimationsController animations;
    [SerializeField] private StateManager stateManager;
    [SerializeField] private Rigidbody2D rb;

    public AnimationsController Animation { get => animations; set => animations = value; }
    public Rigidbody2D Rigidbody { get => rb; set => rb = value; }
    public StateManager StateManager { get => stateManager; set => stateManager = value; }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject _bullet = collision.gameObject.tag == "Weapon" ? collision.gameObject : null;

        if (_bullet == null) return;

        stateManager.ChangeState(stateManager._dieState);
    }
}
