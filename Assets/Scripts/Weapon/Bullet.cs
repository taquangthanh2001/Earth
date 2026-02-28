using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private float damage;

    [SerializeField] private float speed = 15f;

    public void Init(Transform t, float dmg)
    {
        target = t;
        damage = dmg;
    }

    private void Update()
    {
        if (target == null)
        {
            PoolManager.Instance.Despawn(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            IDamageable damageable = target.GetComponent<IDamageable>();

            if (damageable != null)
                damageable.TakeDamage(damage);

            PoolManager.Instance.Despawn(gameObject);
        }
    }
}