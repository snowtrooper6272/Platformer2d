using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _switchDistance;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Vector3 _moveTarget;

    public event Action TargetAchieved;

    private void Update()
    {
        Vector3 offset = _moveTarget - transform.position;

        float sqrLen = Vector3.SqrMagnitude(offset);

        if (sqrLen - _switchDistance <= 0)
        {
            _rigidbody2D.velocity = new Vector3(0,0,0);
            TargetAchieved.Invoke();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = (_moveTarget - transform.position).normalized * _speed;
    }

    public void SetNewTarget(Vector3 target) 
    {
        _moveTarget = target;
    }
}
