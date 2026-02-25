using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ShipShoot : ShipBase
{
    [SerializeField] private WeaponData weaponData;

    private IWeapon weapon;

    private void Awake()
    {
        if (weapon == null)
            weapon = GetComponent<IWeapon>();

        weapon?.Initialize(weaponData, shipController);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (weaponData == null) return;

        RemoveOldWeapons();

        System.Type weaponType = weaponData.GetWeaponType();
        if (weaponType == null) return;

        if (GetComponent(weaponType) == null)
        {
            Undo.AddComponent(gameObject, weaponType);
        }
    }
#endif

    private void RemoveOldWeapons()
    {
#if UNITY_EDITOR
        var bullet = GetComponent<BulletWeapon>();
        if (bullet != null)
            DestroyImmediate(bullet);

        var skill = GetComponent<SkillWeapon>();
        if (skill != null)
            DestroyImmediate(skill);
#endif
    }
}