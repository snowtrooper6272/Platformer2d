using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _patroolPoints;
    [SerializeField] private EnemyMover _mover;

    private int _currentTargetPoint = 0;

    private void OnEnable()
    {
        _mover.TargetAchieved += UpdateMoveTarget;
        _mover.GetNewTarget(_patroolPoints[_currentTargetPoint].position);
    }

    private void OnDisable()
    {
        _mover.TargetAchieved -= UpdateMoveTarget;
    }

    private void UpdateMoveTarget() 
    {
        _currentTargetPoint = ++_currentTargetPoint % _patroolPoints.Length;
        _mover.GetNewTarget(_patroolPoints[_currentTargetPoint].position);
    }
}
