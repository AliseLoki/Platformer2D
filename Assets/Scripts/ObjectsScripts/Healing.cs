using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private int _healingPower;

    public int HealingPower  => _healingPower;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
        }
    }
}
