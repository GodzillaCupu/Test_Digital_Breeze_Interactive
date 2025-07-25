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
}
