using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    [SerializeField] private Chest _chest;
    [SerializeField] private Player _player;
    [SerializeField] private float _maxCoins;

    private void Update()
    {
        Create();
    }

    private void Create()
    {
        if (_player.Score == _maxCoins)
        {
            Instantiate(_chest, transform.position, Quaternion.identity);
            _maxCoins = float.MaxValue;
        }
    }
}
