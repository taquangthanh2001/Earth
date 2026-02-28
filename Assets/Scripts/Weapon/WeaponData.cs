using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Weapon/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public StyleAttack style;

    [ShowIf("style", StyleAttack.AttackBullet)]
    public GameObject bulletPrefab;

    [ShowIf("style", StyleAttack.AttackSkill)]
    public ParticleSystem skillEffect;

    public System.Type GetWeaponType()
    {
        return style switch
        {
            StyleAttack.AttackBullet => typeof(ProjectileWeapon),
            //StyleAttack.AttackSkill => typeof(SkillWeapon),
            _ => null
        };
    }
}

public enum StyleAttack
{
    None = 0,
    AttackBullet = 1,
    AttackSkill = 2,
}