using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour, IWeapon
{
    protected UnitData owner;
    protected float lastAttackTime;

    protected virtual void Awake()
    {
        owner = GetComponent<UnitData>();
    }

    public void TryAttack()
    {
        if (Time.time < lastAttackTime + owner.AttackSpeed)
            return;

        Transform target = FindTarget();
        if (target == null)
            return;

        lastAttackTime = Time.time;
        Execute(target);
    }

    protected abstract Transform FindTarget();
    protected abstract void Execute(Transform target);
}