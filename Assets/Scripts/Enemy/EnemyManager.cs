using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    [SerializeField] private EnemyPool enemyPool;

    private Dictionary<EnemyType, IEnemyBehavior> behaviors = new Dictionary<EnemyType, IEnemyBehavior>();
    private EnemyType currentEnemyType = EnemyType.Enemy1;
    private Enemy currentEnemy;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeBehaviors();
        SpawnEnemy(currentEnemyType);
    }

    private void InitializeBehaviors()
    {
        behaviors[EnemyType.Enemy1] = new EnemyBehavior1();
        behaviors[EnemyType.Enemy2] = new EnemyBehavior2();
        behaviors[EnemyType.Enemy3] = new EnemyBehavior3();
    }

    private void Update()
    {
        // Дополнительная логика управления врагами
    }

    public void OnPlayerAttackChanged(int attackIndex)
    {
        // Смена врага при смене атаки игрока
        EnemyType nextType = (EnemyType)attackIndex;
        SpawnEnemy(nextType);
    }

    private void SpawnEnemy(EnemyType type)
    {
        // Возвращаем предыдущего врага в пул
        if (currentEnemy != null)
        {
            enemyPool.ReturnEnemy(currentEnemyType, currentEnemy);
        }

        // Получаем нового врага
        currentEnemyType = type;
        currentEnemy = enemyPool.GetEnemy(type);

        if (currentEnemy != null && behaviors.ContainsKey(type))
        {
            currentEnemy.SetBehavior(behaviors[type]);
        }
    }
}