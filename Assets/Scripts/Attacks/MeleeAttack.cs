using UnityEngine;

public class MeleeAttack : AttackStrategy
{
    [SerializeField] private Animator animator;

    public override void Attack()
    {
        Debug.Log("Performing Melee Attack!");
        if (animator != null)
        {
            animator.Play("Attack");
        }
    }

    public override string GetAttackName()
    {
        return "Melee Attack";
    }
}