using UnityEngine;

public class MagicAttack : AttackStrategy
{
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem magicEffect;

    public override void Attack()
    {
        Debug.Log("Performing Magic Attack!");
        if (animator != null)
        {
            animator.Play("Attack");
        }

        if (magicEffect != null)
        {
            magicEffect.Play();
        }
    }

    public override string GetAttackName()
    {
        return "Magic Attack";
    }
}