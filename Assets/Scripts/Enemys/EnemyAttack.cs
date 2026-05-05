using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Transform earth;

    public float attackRange = 12f;
    public float fireRate = 1f;

    float timer;
    bool attacking;

    public void Init(Transform earthTarget)
    {
        earth = earthTarget;
    }

    public void StartAttack()
    {
        attacking = true;
    }

    void Update()
    {
        if (!attacking || earth == null) return;

        float dist = Vector3.Distance(transform.position, earth.position);

        if (dist > attackRange) return;

        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            timer = 0f;
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log(name + " attack Earth");
    }
}