using UnityEngine;

public class BulletWeapon : BaseWeapon
{
    [SerializeField] private GameObject bulletPrefab;

    protected override void ExecuteAttack(Transform target)
    {
        Vector3 spawnPos = transform.position;

        GameObject bullet = PoolManager.Instance.Spawn(
            bulletPrefab,
            spawnPos,
            Quaternion.identity
        );

        Vector3 dir = (target.position - spawnPos).normalized;
        bullet.transform.forward = dir;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript?.Init(target);
    }
}