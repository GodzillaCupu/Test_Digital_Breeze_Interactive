using UnityEditor.Animations;
using UnityEngine;

public class AttackState : BaseState
{
    GameObject mainObject;
    IAttack _attackController;
    GameObject bulletObject;
    Transform spawnPoint;

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

        Attack();
    }

    public override void OnUpdate(StateManager manager)
    {
        // Logic for updating the attack state
    }

    public override void OnFixedUpdate(StateManager manager)
    {

    }

    public override void OnCollisionEnter(Collision2D other)
    {
        // Logic for handling collisions in the attack state
    }

    public override void OnExit(StateManager manager)
    {
        // Logic for exiting the attack state
    }

    public void Attack()
    {
        // if (bulletObject == null) return;

        // GameObject _bullet = GameObject.Instantiate(bulletObject, spawnPoint.position, mainObject.transform.rotation);
        animation.PlayAnimations("Attack");
    }
}