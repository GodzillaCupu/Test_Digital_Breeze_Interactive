using UnityEngine;

public class AttackState : BaseState
{
    IAttack _attackController;
    GameObject mainObject;
    GameObject bulletObject;
    GameObject rendererObject;
    Transform spawnPoint;
    float throwSpeed;

    AnimationsController animation;
    public override void OnEnter(StateManager manager)
    {
        // Logic for entering the attack state
        mainObject = manager.gameObject;
        _attackController = mainObject.GetComponent<IAttack>();
        bulletObject = _attackController.Bullet;
        spawnPoint = _attackController.SpawnBulletPostions;

        IController controller = mainObject.GetComponent<IController>();
        animation = controller.Animation;
        rendererObject = animation.gameObject;
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the attack state
        if (_attackController.CanAttack) Attack();
    }

    public override void OnFixedUpdate(StateManager manager)
    {

    }

    public override void OnCollisionEnter(StateManager manager, Collision2D other)
    {
        // Logic for handling collisions in the attack state
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the attack state
        _attackController.CanAttack = true;
        bulletObject = null;
        mainObject = null;
        _attackController = null;
        spawnPoint = null;
        animation = null;
        rendererObject = null;
    }

    public void Attack()
    {
        // if (bulletObject == null) return;
        Quaternion _flipQuarternion = Quaternion.Euler(0, 180, 0);
        bool isFlip = rendererObject.transform.rotation == _flipQuarternion ?
                true : false;
        GameObject _bullet;

        if (bulletObject == null) return;
        if (isFlip)
            _bullet = GameObject.Instantiate(bulletObject, spawnPoint.position, mainObject.transform.rotation);
        else
            _bullet = GameObject.Instantiate(bulletObject, spawnPoint.position, _flipQuarternion);
           
        throwSpeed = _bullet.GetComponent<BaseWeapon>().SpeedThrow;
        _attackController.CanAttack = false;
        animation.PlayAnimations("Attack");
    }
}