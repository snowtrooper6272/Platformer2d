using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _moveTarget;

    public event Action TargetAchieved;

    private void Update()
    {
        if (transform.position.x != _moveTarget.x)
            transform.position = Vector3.MoveTowards(transform.position, _moveTarget, _speed * Time.deltaTime);
        else
            TargetAchieved.Invoke();
    }

    public void SetNewTarget(Vector3 target) 
    {
        _moveTarget = target;
    }
}
