using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public bool IsJumpKeyDown { get; private set; }
    
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpForce;

    private KeyCode _jumpKey = KeyCode.Space;
    private bool _isPossibleJump = false;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey) && _isPossibleJump)
            IsJumpKeyDown = true;
    }

    public void SetGrounded()
    {
        _isPossibleJump = true;
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce);
        _isPossibleJump = false;
        IsJumpKeyDown = false;
    }
}
