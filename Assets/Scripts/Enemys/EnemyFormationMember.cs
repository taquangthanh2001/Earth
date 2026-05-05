using UnityEngine;

public class EnemyFormationMember : MonoBehaviour
{
    private Vector3 offset;
    private Transform leader;

    private bool formationStopped;

    public void Init(Transform formationLeader, Vector3 localOffset)
    {
        leader = formationLeader;
        offset = localOffset;
    }

    void Update()
    {
        if (leader == null) return;

        if (!formationStopped)
        {
            transform.position = leader.position + offset;
        }
    }

    void OnFormationStop()
    {
        formationStopped = true;

        EnemyAttack attack = GetComponent<EnemyAttack>();

        if (attack != null)
            attack.StartAttack();
    }
}