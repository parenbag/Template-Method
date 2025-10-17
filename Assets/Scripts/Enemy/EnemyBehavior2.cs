using UnityEngine;

public class EnemyBehavior2 : IEnemyBehavior
{
    private Enemy enemy;
    private float attackTimer = 0f;
    private const float ATTACK_INTERVAL = 1.5f;

    public void Initialize(Enemy enemy)
    {
        this.enemy = enemy;
        enemy.Show();
    }

    public void Execute()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= ATTACK_INTERVAL)
        {
            enemy.PlayAttackAnimation();
            enemy.Shoot();
            attackTimer = 0f;
        }
        else
        {
            enemy.PlayIdleAnimation();
        }
    }

    public void Disable()
    {
        enemy.Hide();
    }
}