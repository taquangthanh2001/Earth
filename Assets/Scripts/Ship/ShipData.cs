using UnityEngine;

public abstract class ShipData : MonoBehaviour, IShipData
{
    [SerializeField] private ShipDataSO shipDataSO;

    private float _currentHp;

    protected virtual void Awake()
    {
        _currentHp = shipDataSO.Hp;
    }

    public float AttackSpeed() => shipDataSO.AttackSpeed;
    public float AttackRange() => shipDataSO.AttackRange;
    public float Damage() => shipDataSO.Damage;
    public float HP() => _currentHp;

    public bool IsDeath() => _currentHp <= 0;

    public void ReceiveDamage(float damageReceive)
    {
        _currentHp -= damageReceive;
    }
}