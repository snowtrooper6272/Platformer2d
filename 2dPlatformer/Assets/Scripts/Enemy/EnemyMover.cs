using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Action TargetAchieved;

    private Vector3 _moveTarget;

    private void Update()
    {
        if (transform.position.x != _moveTarget.x)
            transform.position = Vector3.MoveTowards(transform.position, _moveTarget, _speed * Time.deltaTime);
        else
            TargetAchieved.Invoke();
    }

    public void GetNewTarget(Vector3 target) 
    {
        _moveTarget = target;
    }
}
