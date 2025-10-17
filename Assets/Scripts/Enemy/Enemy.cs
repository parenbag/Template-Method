using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    protected IEnemyBehavior behavior;

    public void SetBehavior(IEnemyBehavior newBehavior)
    {
        behavior?.Disable();
        behavior = newBehavior;
        behavior?.Initialize(this);
    }

    private void Update()
    {
        behavior?.Execute();
    }

    public abstract void Show();
    public abstract void Hide();
    public abstract void PlayAttackAnimation();
    public abstract void PlayIdleAnimation();
    public abstract void Shoot();
}