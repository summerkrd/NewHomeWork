using UnityEngine;

public class IdlePointsPatrol : IIdleAction
{
    private Transform[] _targetTransform;
    private Transform _enemyTransform;
    private int _currentTargetIndex = -1;
    private float _moveSpeed = 5f;

    public IdlePointsPatrol(Transform[] pointsTransform, Transform enemyTransform)
    {
        _targetTransform = pointsTransform;
        _enemyTransform = enemyTransform;
    }

    public void Action()
    {
        if(_currentTargetIndex == -1 || Vector3.Distance(_enemyTransform.position, _targetTransform[_currentTargetIndex].position) < 0.1f)
        {
            SetNewTarget();
        }

        MoveToTarget();
    }

    public void SetNewTarget()
    {
        _currentTargetIndex = Random.Range(0, _targetTransform.Length);
    }

    public void MoveToTarget()
    {
        Vector3 direction = _targetTransform[_currentTargetIndex].position - _enemyTransform.position;
        Vector3 normalizeDirection = Vector3.Normalize(direction);

        _enemyTransform.position += normalizeDirection * Time.deltaTime * _moveSpeed;
    }
}
