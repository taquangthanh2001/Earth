using UnityEngine;

public class SkillWeapon : BaseWeapon
{
    [SerializeField] private ParticleSystem skillEffect;

    protected override void ExecuteAttack(Transform target)
    {
        GameObject effectObj = PoolManager.Instance.Spawn(
            skillEffect.gameObject,
            target.position,
            Quaternion.identity
        );

        ParticleSystem ps = effectObj.GetComponent<ParticleSystem>();
        ps.Play();

        StartCoroutine(ReturnAfter(ps));
    }

    private System.Collections.IEnumerator ReturnAfter(ParticleSystem ps)
    {
        yield return new WaitForSeconds(ps.main.duration);
        PoolManager.Instance.Despawn(ps.gameObject);
    }
}