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

        
        enemy.PlayAttackAnimation();
        hasAttacked = true;
    }

    public void Execute()
    {
       
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