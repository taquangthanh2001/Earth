using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour, IWeapon
{
    [Header("Attack Settings")]
    [SerializeField] protected LayerMask targetLayer;

    private ShipController shipController;
    protected float lastAttackTime;

    protected virtual void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (!CanAttack()) return;

        Transform target = GetNearestTarget();
        if (target == null) return;

        lastAttackTime = Time.time;
        ExecuteAttack(target);
    }

    protected abstract void ExecuteAttack(Transform target);

    protected bool CanAttack()
    {
        return Time.time >= lastAttackTime + shipController.AttackSpeed();
    }

    protected Transform GetNearestTarget()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            shipController.AttackRange(),
            targetLayer
        );

        float minDist = Mathf.Infinity;
        Transform nearest = null;

        foreach (var hit in hits)
        {
            float dist = Vector3.Distance(
                transform.position,
                hit.transform.position
            );

            if (dist < minDist)
            {
                minDist = dist;
                nearest = hit.transform;
            }
        }

        return nearest;
    }

    public void Initialize(WeaponData data, ShipController shipController)
    {
        this.shipController = shipController;
    }
}