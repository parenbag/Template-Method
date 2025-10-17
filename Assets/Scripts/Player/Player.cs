using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AttackStrategy[] attacks;
    private int currentAttackIndex = 0;
    private AttackStrategy currentAttack;

    public bool IsAttacking { get; private set; }

    private void Start()
    {
        if (attacks.Length > 0)
        {
            currentAttack = attacks[0];
        }
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchToNextAttack();
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformAttack();
        }
    }

    private void SwitchToNextAttack()
    {
        currentAttackIndex = (currentAttackIndex + 1) % attacks.Length;
        currentAttack = attacks[currentAttackIndex];

        Debug.Log($"Switched to: {currentAttack.GetAttackName()}");

        
        EnemyManager.Instance?.OnPlayerAttackChanged(currentAttackIndex);
    }

    private void PerformAttack()
    {
        if (currentAttack != null)
        {
            currentAttack.Attack();
            IsAttacking = true;

            
            Invoke(nameof(ResetAttackFlag), 0.5f);
        }
    }

    private void ResetAttackFlag()
    {
        IsAttacking = false;
    }
}