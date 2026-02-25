using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed = 15f;

    public void Init(Transform t)
    {
        target = t;
    }

    void Update()
    {
        if (target == null)
        {
            PoolManager.Instance.Despawn(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            PoolManager.Instance.Despawn(gameObject);
        }
    }
}