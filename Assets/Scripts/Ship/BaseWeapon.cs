using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour, IWeapon
{
    protected UnitData owner;
    protected float lastAttackTime;

    [Header("Rotation")]
    [SerializeField] protected bool rotateToTarget = true;
    [SerializeField] protected float rotateSpeed = 10f;
    [SerializeField] protected bool lockYRotation = false;

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

        if (rotateToTarget)
            RotateTowards(target);

        lastAttackTime = Time.time;
        Execute(target);
    }

    protected void RotateTowards(Transform target)
    {
        Vector3 direction = target.position - transform.position;

        if (lockYRotation)
            direction.y = 0f;

        if (direction == Vector3.zero)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotateSpeed * Time.deltaTime
        );
    }

    protected abstract Transform FindTarget();
    protected abstract void Execute(Transform target);
}