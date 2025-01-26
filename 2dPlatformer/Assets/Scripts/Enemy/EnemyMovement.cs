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
            _currentTargetPoint = ++_currentTargetPoint % _patroolPoints.Length;
        }
    }
}
