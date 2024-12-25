using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    private const string StartWalk = nameof(StartWalk);

    private Animator _animator;
    private float _duration = 0.5f;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public IEnumerator StartMove(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            _animator.SetBool(StartWalk, true);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _duration);
            yield return null;
        }

        _animator.SetBool(StartWalk, false);
    }
}
