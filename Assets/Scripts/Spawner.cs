using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _enemySpawnPoint;

    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform[] _coinSpawnPoints;

    [SerializeField] private GameObject _chest;
    [SerializeField] private Transform _chestSpawnPoint;

    private void Start()
    {
        CreateObject(_enemy, _enemySpawnPoint);
        CreateObject(_chest, _chestSpawnPoint);
        CreateObjects(_coin, _coinSpawnPoints);
    }

    private void CreateObject(GameObject spawnObject, Transform spawnPoint)
    {
        Instantiate(spawnObject, spawnPoint.position, Quaternion.identity);
    }

    private void CreateObjects(GameObject spawnObject, Transform[] spawnPoints)
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(spawnObject, spawnPoint.position, Quaternion.identity);
        }
    }
}
