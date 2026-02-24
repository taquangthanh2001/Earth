using UnityEngine;

public interface IShipData
{
    public float HP();
    public float Damage();
    public float AttackSpeed();
    public bool IsDeath();
    public void ReceiveDamage(float damageReceive);
}
