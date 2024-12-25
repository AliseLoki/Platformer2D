using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ButtonColorChanger : MonoBehaviour
{
    [SerializeField] private PlayerMover _player;

    private Animator _animator;
    private Vector3 _position;

    private void Start()
    {
        _position = GetComponent<Transform>().position;
        _animator = GetComponent<Animator>();
    }
    public void OnButtonClick()
    {
        StartCoroutine(_player.StartMove(_position));
        _animator.SetBool("Start", true);
    }
}
