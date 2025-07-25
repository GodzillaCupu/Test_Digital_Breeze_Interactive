using UnityEngine;

public class Kunai : BaseWeapon
{
    public string Id = "Kunai";

    private void OnEnable()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.position += -transform.right * SpeedThrow * Time.deltaTime;
    }

}
