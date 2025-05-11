using System;
using UnityEngine;

[RequireComponent(typeof(GroundChecker), typeof(PlayerAnimator))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private InputReader _moveReader;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private GroundChecker _groundChecker;

    public float MoveSpeed => _moveSpeed;

    private int _speed = Animator.StringToHash(nameof(_speed));
    private bool _isPossibleJump = true;

    private void OnEnable()
    {
        _moveReader.PlayerJumped += Jump;
        _groundChecker.Grounded += SetGrounded;
    }

    private void OnDisable()
    {
        _moveReader.PlayerJumped -= Jump;
    }

    private void SetGrounded() 
    {
        _isPossibleJump = true;
    }

    private void FixedUpdate()
    {
        transform.Translate(Math.Abs(_moveReader.AxisDirection) * Time.deltaTime * _moveSpeed, 0, 0);
        _cameraMover.Move(transform.position.x);

        _animator.PlayRun(_moveReader.AxisDirection);
    }

    private void Jump() 
    {
        if (_isPossibleJump)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _animator.PlayJump();
            _isPossibleJump = false;
        }
    }
}
