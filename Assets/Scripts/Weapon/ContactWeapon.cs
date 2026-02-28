using UnityEngine;

public class ContactWeapon : BaseWeapon
{
    [SerializeField] private LayerMask earthLayer;

    protected override Transform FindTarget()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            1f,
            earthLayer);

        return hits.Length > 0 ? hits[0].transform : null;
    }

    protected override void Execute(Transform target)
    {
        IDamageable damageable = target.GetComponent<IDamageable>();

        if (damageable != null)
            damageable.TakeDamage(owner.Damage);

        PoolManager.Instance.Despawn(gameObject);
    }
}