using UnityEngine;

public class Kunai : BaseWeapon
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnHit(collision);
    }
}
