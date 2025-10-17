using UnityEngine;

public class Enemy3 : Enemy
{
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
        // Враг 3 не стреляет самостоятельно
    }
}