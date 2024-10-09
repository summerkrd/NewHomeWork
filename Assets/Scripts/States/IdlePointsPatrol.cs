using UnityEngine;

public class IdlePointsPatrol : IEnemyState
{
    private Transform[] _pointsTransform;
    private int _currentTargetIndex;
    private float _moveSpeed;

    public IdlePointsPatrol(Transform[] points)
    {
        _pointsTransform = points;
    }

    public void Action(Enemy enemy, Player player)
    {
        SetNewTarget();

    }

    private void SetNewTarget()
    {
        _currentTargetIndex = Random.Range(0, _pointsTransform.Length);
    }
}
