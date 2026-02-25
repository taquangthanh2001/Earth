using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Ship/Ship Data")]
public class ShipDataSO : ScriptableObject
{
    public float Hp;
    public float Damage;
    public float AttackSpeed;
    public float AttackRange;
}
