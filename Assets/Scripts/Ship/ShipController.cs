using UnityEngine;

public class ShipController : MonoBehaviour
{
    private IWeapon weapon;

    private void Awake()
    {
        weapon = GetComponent<IWeapon>();
    }

    private void Update()
    {
        weapon.TryAttack();
    }
}