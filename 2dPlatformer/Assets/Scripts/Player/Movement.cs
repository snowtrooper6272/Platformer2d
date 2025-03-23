using System;
using UnityEngine;

[RequireComponent(typeof(GroundChecker), typeof(AnimationConroller))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private InputReader _moveReader;
    [SerializeField] private AnimationConroller _animationConroller;

    public float MoveSpeed => _moveSpeed;

    private GroundChecker _groundChecker;
    private bool _isOnGround = true;
    private int _speed = Animator.StringToHash(nameof(_speed));

    private void OnEnable()
    {
        _moveReader.PlayerJumped += Jump;
        _groundChecker = GetComponent<GroundChecker>();
    }

    private void OnDisable()
    {
        _moveReader.PlayerJumped -= Jump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground)) 
        {
            _isOnGround = true;
        }
    }

    private void Update()
    {
        transform.Translate(_moveReader.AxisDirection * Time.deltaTime * _moveSpeed, 0, 0);

        _animationConroller.PlayRun(_moveReader.AxisDirection);
    }

    private void Jump() 
    {
        if (_groundChecker.IsPossibleJump) 
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _isOnGround = false;
            _animationConroller.PlayJump();
            _groundChecker.TakeOff();
        }
    }
}
