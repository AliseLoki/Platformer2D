using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const string FirstPoint = nameof(FirstPoint);
    private const string LastPoint = nameof(LastPoint);

    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _enemySpriteRenderer;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Transform _currentPoint;

    private float _waitingTime = 2f;

    private void OnEnable()
    {
        _currentPoint = GameObject.FindWithTag(FirstPoint).GetComponent<Transform>();
        _targetPoint = GameObject.FindWithTag(LastPoint).GetComponent<Transform>();
        _enemySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        var pause = new WaitForSeconds(_waitingTime);

        while (true)
        {
            while (transform.position != _targetPoint.position)
            {
                _enemySpriteRenderer.flipX = false;
                transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, _speed * Time.deltaTime);
                yield return null;
            }

            yield return pause;

            while (transform.position != _currentPoint.position)
            {
                _enemySpriteRenderer.flipX = true;
                transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);
                yield return null;
            }

            yield return pause;
        }
    }
}
