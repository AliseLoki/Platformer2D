using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] private Enemy[] _enemy;
    [SerializeField] private Transform[] _enemySpawnPoint;
    [SerializeField] private Player _player;

    private void Start()
    {
        CreateEnemy();
    }

    private void CreateEnemy()
    {
        for (int i = 0, j = 0; i < _enemy.Length && j < _enemySpawnPoint.Length; i++, j++)
        {
          Object obj =  Spawn(_enemy[i], _enemySpawnPoint[j].position, Quaternion.identity);
          Enemy enemy = obj as Enemy;
            enemy.Initialize(_player);
        }
    }
}
