using NUnit.Framework.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private float speedThrow;
    [SerializeField] private float damage;

    [SerializeField] private bool canThrow;

    public bool CanThrow { get => canThrow; set => canThrow = value; }
    public float SpeedThrow { get => speedThrow; set => speedThrow = value; }
    public float Damage { get => damage; set => damage = value; }

    public void OnHit(Collision2D collision)
    {
        bool _hitEnemy = collision.collider.tag == "enemy";
        bool _hitPlayer = collision.collider.tag == "player"; ;
        var _hitObject = _hitEnemy || _hitPlayer;

        if (!_hitObject) return;

        if (_hitEnemy)
        {
            GameObject _enemyObject = collision.gameObject;
            StateManager _stateManagerEnemy = _enemyObject.GetComponent<StateManager>();
            _stateManagerEnemy.ChangeState(_stateManagerEnemy._dieState);
        }

        if (_hitPlayer)
        {
            GameObject _playerObject = collision.gameObject;
            StateManager _stateManagerPlayer = _playerObject.GetComponent<StateManager>();
            PlayerController _controller = _playerObject.GetComponent<PlayerController>();

            _controller.Health -= damage;
            _stateManagerPlayer.ChangeState(_stateManagerPlayer._hurtState);

        }
    }
}
