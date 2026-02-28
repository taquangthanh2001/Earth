using UnityEngine;

public class UnitData : MonoBehaviour, IDamageable
{
    [SerializeField] private UnitStatsSO stats;
    [SerializeField] private int goldReward = 0;

    private float currentHp;

    public float Damage => stats.damage;
    public float AttackSpeed => stats.attackSpeed;
    public float AttackRange => stats.attackRange;
    public float MoveSpeed => stats.moveSpeed;

    private void OnEnable()
    {
        currentHp = stats.maxHp;
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
            Die();
    }

    protected virtual void Die()
    {
        if (goldReward > 0)
            CurrencyManager.Instance.AddGold(goldReward);

        PoolManager.Instance.Despawn(gameObject);
    }
}