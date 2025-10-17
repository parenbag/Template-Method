using UnityEngine;

public class RangeAttack : AttackStrategy
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;

    public override void Attack()
    {
        Debug.Log("Performing Range Attack!");
        if (animator != null)
        {
            animator.Play("Attack");
        }

        if (projectilePrefab != null && shootPoint != null)
        {
            Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        }
    }

    public override string GetAttackName()
    {
        return "Range Attack";
    }
}