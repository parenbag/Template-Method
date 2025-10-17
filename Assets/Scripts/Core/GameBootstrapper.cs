using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private Player player;

    private void Awake()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        // Находим или создаем основные компоненты
        if (enemyPool == null)
            enemyPool = FindObjectOfType<EnemyPool>();

        if (enemyManager == null)
            enemyManager = FindObjectOfType<EnemyManager>();

        if (player == null)
            player = FindObjectOfType<Player>();

        Debug.Log("Game initialized successfully!");
    }
}