using UnityEngine;

public class EnemyBehavior3 : IEnemyBehavior
{
    private Enemy enemy;
    private Player player;

    public void Initialize(Enemy enemy)
    {
        this.enemy = enemy;
        this.player = GameObject.FindObjectOfType<Player>();
        enemy.Show();
    }

    public void Execute()
    {
        // Синхронизация с состоянием игрока
        if (player != null && player.IsAttacking)
        {
            enemy.PlayAttackAnimation();
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