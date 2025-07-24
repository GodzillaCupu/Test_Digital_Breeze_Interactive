using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private float speedThrow;
    [SerializeField] private float damage;

    [SerializeField] private bool canThrow;

    public bool CanThrow { get => canThrow; set => canThrow = value; }
    public float SpeedThrow { get =>speedThrow ; set => speedThrow = value; }
    public float Damage { get => damage; set => damage = value; }

    private void OCollisionEnter2D(Collision2D collision)
    {
        var _hitObject = collision.collider.tag == "enemy" || collision.collider.tag == "player";

        if (!_hitObject) return;

        StateManager _stateManager = collision.gameObject.GetComponent<StateManager>();
        _stateManager.ChangeState(_stateManager._dieState);
    }
}
