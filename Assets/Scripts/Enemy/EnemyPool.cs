using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [System.Serializable]
    public class EnemyPoolItem
    {
        public EnemyType type;
        public Enemy prefab;
        public int poolSize;
    }

    [SerializeField] private List<EnemyPoolItem> poolItems;
    private Dictionary<EnemyType, Queue<Enemy>> pools = new Dictionary<EnemyType, Queue<Enemy>>();
    private Dictionary<EnemyType, Enemy> activeEnemies = new Dictionary<EnemyType, Enemy>();

    private void Start()
    {
        InitializePools();
    }

    private void InitializePools()
    {
        foreach (var item in poolItems)
        {
            Queue<Enemy> pool = new Queue<Enemy>();

            for (int i = 0; i < item.poolSize; i++)
            {
                Enemy enemy = Instantiate(item.prefab, transform);
                enemy.gameObject.SetActive(false);
                pool.Enqueue(enemy);
            }

            pools[item.type] = pool;
        }
    }

    public Enemy GetEnemy(EnemyType type)
    {
        if (pools.ContainsKey(type) && pools[type].Count > 0)
        {
            Enemy enemy = pools[type].Dequeue();
            activeEnemies[type] = enemy;
            return enemy;
        }

        return null;
    }

    public void ReturnEnemy(EnemyType type, Enemy enemy)
    {
        if (pools.ContainsKey(type))
        {
            enemy.Hide();
            pools[type].Enqueue(enemy);
            activeEnemies.Remove(type);
        }
    }

    public Enemy GetActiveEnemy(EnemyType type)
    {
        return activeEnemies.ContainsKey(type) ? activeEnemies[type] : null;
    }
}