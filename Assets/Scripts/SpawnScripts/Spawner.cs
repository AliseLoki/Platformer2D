using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public Object Spawn(Object prefab, Vector3 position, Quaternion quaternion)
    {
        return
        Instantiate(prefab, position, quaternion);
    }
}
