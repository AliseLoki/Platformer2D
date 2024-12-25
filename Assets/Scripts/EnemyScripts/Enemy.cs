using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _targetPoint;
    [SerializeField] private Vector3 _currentPoint;

    private float _waitingTime = 1f;
    private SpriteRenderer _enemySpriteRenderer;
    private Coroutine _patrol;
    private Coroutine _following;
    private Player _player;

    public int Damage => _damage;

    private void Start()
    {
        _enemySpriteRenderer = GetComponent<SpriteRenderer>();
        _patrol = StartCoroutine(Patrol());
    }

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_patrol != null)
            {
                StopCoroutine(_patrol);
            }

            _following = StartCoroutine(Following());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_following != null)
            {
                StopCoroutine(_following);
            }

            _patrol = StartCoroutine(Patrol());
        }
    }

    private IEnumerator Following()
    {
        if (_player != null && _enemySpriteRenderer.flipX == true)
        {
            while (transform.position != _player.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
                yield return null;
            }
        }
    }

    private IEnumerator Patrol()
    {
        var pause = new WaitForSeconds(_waitingTime);

        while (true)
        {
            while (transform.position != _targetPoint)
            {
                _enemySpriteRenderer.flipX = false;
                transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _speed * Time.deltaTime);
                yield return null;
            }

            yield return pause;

            while (transform.position != _currentPoint)
            {
                _enemySpriteRenderer.flipX = true;
                transform.position = Vector3.MoveTowards(transform.position, _currentPoint, _speed * Time.deltaTime);
                yield return null;
            }

            yield return pause;
        }
    }
}
