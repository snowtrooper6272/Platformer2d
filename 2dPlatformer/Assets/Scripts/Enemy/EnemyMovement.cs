using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _patroolPoints;
    [SerializeField] private float _speed;

    private int _currentTargetPoint = 0;

    private void Update()
    {
        if (transform.position.x != _patroolPoints[_currentTargetPoint].position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, _patroolPoints[_currentTargetPoint].position, _speed * Time.deltaTime);
        }
        else
        {
            if (_currentTargetPoint < _patroolPoints.Length - 1)
                _currentTargetPoint++;
            else
                _currentTargetPoint = 0;
        }
    }
}
