using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _points;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (var point in _points)
        {
            Spawn(_coin, point.transform.position, Quaternion.identity);
        }
    }
}
