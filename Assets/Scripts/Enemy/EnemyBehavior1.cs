using UnityEngine;

public class EnemyBehavior1 : IEnemyBehavior
{
    private Enemy enemy;
    private bool hasAttacked = false;

    public void Initialize(Enemy enemy)
    {
        this.enemy = enemy;
        hasAttacked = false;
        enemy.Show();

        // Ќемедленно выполн€ем атаку при по€влении
        enemy.PlayAttackAnimation();
        hasAttacked = true;
    }

    public void Execute()
    {
        // ѕосле первой атаки просто бездействуем
        if (hasAttacked)
        {
            enemy.PlayIdleAnimation();
        }
    }

    public void Disable()
    {
        enemy.Hide();
    }
}