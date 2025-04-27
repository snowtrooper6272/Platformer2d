using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _patroolPoints;

    private EnemyMover _mover;
    private int _currentTargetPoint = 0;

    private void Start()
    {
        _mover = GetComponent<EnemyMover>();
        _mover.GetNewTarget(_patroolPoints[_currentTargetPoint].position);
    }

    private void Update()
    {
        if (transform.position.x == _patroolPoints[_currentTargetPoint].position.x)
        {
            _currentTargetPoint = ++_currentTargetPoint % _patroolPoints.Length;
            _mover.GetNewTarget(_patroolPoints[_currentTargetPoint].position);
        }
    }
}
