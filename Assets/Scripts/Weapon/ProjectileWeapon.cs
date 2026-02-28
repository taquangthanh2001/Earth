using UnityEngine;

public class ProjectileWeapon : BaseWeapon
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private LayerMask enemyLayer;

    protected override Transform FindTarget()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            owner.AttackRange,
            enemyLayer);

        return hits.Length > 0 ? hits[0].transform : null;
    }

    protected override void Execute(Transform target)
    {
        GameObject bullet = PoolManager.Instance.Spawn(
            bulletPrefab,
            transform.position,
            Quaternion.identity);

        bullet.GetComponent<Bullet>().Init(target, owner.Damage);
    }
}