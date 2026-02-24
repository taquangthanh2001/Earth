using UnityEngine;

public interface IShoot
{
    public void Shoot(GameObject bullet, Transform target);
    public void Shoot(ParticleSystem effectBullet, Transform target);
}
