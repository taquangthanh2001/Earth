using UnityEngine;

public class FormationController : MonoBehaviour
{
    public Transform earth;
    public float moveSpeed = 4f;
    public float stopDistance = 15f;

    private bool stopped;

    void Update()
    {
        if (stopped) return;

        Vector3 dir = (earth.position - transform.position).normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;

        float dist = Vector3.Distance(transform.position, earth.position);

        if (dist <= stopDistance)
        {
            stopped = true;

            SendMessage(
                "OnFormationStop",
                SendMessageOptions.DontRequireReceiver
            );
        }
    }
}