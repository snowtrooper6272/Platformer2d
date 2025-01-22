using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _reflector;
    [SerializeField] private Animator _animator;

    private bool _isOnGround = true;

    private void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * _speed * Time.deltaTime,0, 0);

        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                _reflector.flipX = true;
            }
            else
            {
                _reflector.flipX = false;
            }
        }
        else 
        {
            _animator.Play("idle");
        }

        _animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _isOnGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground)) 
        {
            _isOnGround = true;
        }
    }
}
