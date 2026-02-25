public interface IWeapon
{
    void Initialize(WeaponData data, ShipController shipController);
    void Attack();
}