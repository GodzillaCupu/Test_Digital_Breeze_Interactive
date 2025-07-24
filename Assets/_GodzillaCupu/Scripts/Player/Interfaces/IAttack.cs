using UnityEngine;

public interface IAttack
{
    bool CanAttack { get; set; }

    void OnAttack();
}
