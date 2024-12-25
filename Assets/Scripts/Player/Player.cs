using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const string StartRun = nameof(StartRun);

    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityModifier;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Slider _healthbar;

    private float _score;
    private Animator _animator;

    public float Score => _score;
    public int Health => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthbar.value = _currentHealth;
        _animator = GetComponent<Animator>();
        Physics2D.gravity *= _gravityModifier;
    }

    private void Update()
    {
        _healthbar.value = _currentHealth;
        Move();

        if(_currentHealth == _minHealth)
        {
            Time.timeScale = 0;
        }
    }

    public void ChangeHealth(int value)
    {
        _currentHealth += value;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        if(_currentHealth < _minHealth)
            _currentHealth = _minHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Coin coin))
        {
            _score += 1;
        }

        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            ChangeHealth(-enemy.Damage);
        }

        if (collision.collider.TryGetComponent(out Healing healing))
        {
            ChangeHealth(healing.HealingPower);
        }
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
}
