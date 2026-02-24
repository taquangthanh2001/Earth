using Sirenix.OdinInspector;
using UnityEngine;

public abstract class ShipData : MonoBehaviour, IShipData
{
    [SerializeField] private float _hp;
    [SerializeField] private float _damage;
    [SerializeField] private float _attack_speed;

    [ShowIf("_styleAttack", StyleAttack.AttackBullet)]
    [SerializeField] private GameObject _bullet;


    [ShowIf("_styleAttack", StyleAttack.AttackSkill)]
    [SerializeField] private ParticleSystem _bulletEffect;

    [SerializeField] private StyleAttack _styleAttack;

    public float AttackSpeed() => _attack_speed;
    public float Damage() => _damage;
    public float HP() => _hp;
    public bool IsDeath() => _hp <= 0;
    public void ReceiveDamage(float damageReceive)
    {
        _hp -= damageReceive;
    }
}

public enum StyleAttack
{
    None = 0,
    AttackBullet = 1,
    AttackSkill = 2,
}