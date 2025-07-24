using UnityEngine;

public interface IWeapon
{
    bool CanThrow { get; set; }
    float SpeedThrow { get; set; }
    float Damage{ get; set; }
}
