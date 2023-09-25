using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemy;
    [SerializeField] private Transform[] _enemySpawnPoint;

    private void Start()
    {
        CreateEnemy();
    }

    private void CreateEnemy()
    {
        Instantiate(_enemy[0], _enemySpawnPoint[0].position, Quaternion.identity);
        Instantiate(_enemy[1], _enemySpawnPoint[1].position, Quaternion.identity);
    }
}
