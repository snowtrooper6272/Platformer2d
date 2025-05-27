using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float MoveSpeed => _moveSpeed;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rigidbody;

    public void Move(float axisDirection) 
    {
        _rigidbody.velocity = new Vector2(axisDirection * _moveSpeed, _rigidbody.velocity.y);
    }
}
