using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const string StartRun = nameof(StartRun);
    private const string Die = nameof(Die);

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityModifier;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GroundChecker _groundChecker;

    private float _score;
    private Animator _animator;

    public float Score => _score;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        Physics2D.gravity *= _gravityModifier;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetTrigger(StartRun);
            _spriteRenderer.flipX = false;
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _animator.SetTrigger(StartRun);
            _spriteRenderer.flipX = true;
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Space) && _groundChecker.IsGrounded == true)
        {
            _rigidbody2D.AddForce(Vector3.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Coin coin))
        {
            _score += 1;
        }

        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            _animator.SetTrigger(Die);
        }
    }
}
