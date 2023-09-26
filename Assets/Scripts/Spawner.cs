using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public void Spawn(Object prefab, Vector3 position, Quaternion quaternion)
    {
        Instantiate(prefab, position, quaternion);
    }
}
