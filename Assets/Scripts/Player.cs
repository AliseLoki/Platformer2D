using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityModifier;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private float _score;
    private Animator _animator;

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
            _animator.SetTrigger("StartRun");
            _spriteRenderer.flipX = false;
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _animator.SetTrigger("StartRun");
            _spriteRenderer.flipX = true;
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Space) && _isGrounded == true)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;

        if (collision.collider.TryGetComponent(out Coin coin))
        {
            _score += 1;
            Debug.Log("You have " + _score + " coins");
        }

        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            _animator.SetTrigger("Die");
            Debug.Log("YOU ARE DEAD!!!");
            Time.timeScale = 0;
        }
    }
}
