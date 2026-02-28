using UnityEngine;

[CreateAssetMenu(menuName = "Game/Unit Stats")]
public class UnitStatsSO : ScriptableObject
{
    public float maxHp;
    public float damage;
    public float attackSpeed;
    public float attackRange;
    public float moveSpeed;
}