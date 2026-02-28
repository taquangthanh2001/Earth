using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform earth;

    private UnitData unitData;
    private IWeapon weapon;

    private void Awake()
    {
        unitData = GetComponent<UnitData>();
        weapon = GetComponent<IWeapon>();
    }

    public void Init(Transform earthTarget)
    {
        earth = earthTarget;
    }

    private void Update()
    {
        if (earth == null) return;

        MoveToEarth();
        weapon?.TryAttack();
    }

    private void MoveToEarth()
    {
        Vector3 dir = (earth.position - transform.position).normalized;

        transform.position += dir * unitData.MoveSpeed * Time.deltaTime;
        transform.LookAt(earth);
    }
}