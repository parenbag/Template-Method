using UnityEngine;

public class Enemy2 : Enemy
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;

    public override void Show()
    {
        gameObject.SetActive(true);
        PlayIdleAnimation();
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void PlayAttackAnimation()
    {
        if (animator != null)
            animator.Play("Attack");
    }

    public override void PlayIdleAnimation()
    {
        if (animator != null)
            animator.Play("Idle");
    }

    public override void Shoot()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}