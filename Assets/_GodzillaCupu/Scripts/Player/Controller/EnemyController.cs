using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private AnimationsController animations;
    [SerializeField] private Rigidbody2D rb;

    public StateManager stateManager;

    public AnimationsController Animations { get => animations; set => animations = value; }
    public Rigidbody2D Rigidbody { get => rb; set => rb = value; }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject _bullet = collision.gameObject.tag == "Weapon" ? collision.gameObject : null;

        if (_bullet == null) return;

        stateManager.ChangeState(stateManager._dieState);
    }

}
