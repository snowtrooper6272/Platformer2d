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
    [SerializeField] private HorizontalMover _cameraMover;
    [SerializeField] private GroundChecker _groundChecker;
    
    public float MoveSpeed => _moveSpeed;

    private bool _isPossibleJump = true;
    private KeyCode _jumpButton = KeyCode.Space;
    private bool _isJumping = false;

    private void OnEnable()
    {
        _groundChecker.Grounded += SetGrounded;
    }

    private void OnDisable()
    {
        _groundChecker.Grounded -= SetGrounded;
    }

    private void Update()
    {
        _animator.PlayRun(_moveReader.AxisDirection, _moveSpeed);

        if (Input.GetKeyDown(_jumpButton) && _isPossibleJump == true) 
        {
            _isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_moveReader.AxisDirection * _moveSpeed, _rigidbody.velocity.y);

        if (_isJumping)
            Jump();
    }

    private void SetGrounded() 
    {
        _isPossibleJump = true;
        _animator.Aterrissagem();
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce);
        _animator.PlayJump();
        _isPossibleJump = false;
        _isJumping = false;
    }
}
