using UnityEngine;

public abstract class AttackStrategy : MonoBehaviour
{
    public abstract void Attack();
    public abstract string GetAttackName();
}