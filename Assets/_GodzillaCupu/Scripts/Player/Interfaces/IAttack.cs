using UnityEngine;

public interface IAttack
{
    GameObject Bullet{ get; set; }
    Transform SpawnBulletPostions{ get; set; }
    bool CanAttack { get; set; }

    void OnAttack();
}
