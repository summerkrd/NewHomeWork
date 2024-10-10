using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private IdleAction _idleEnum;
    [SerializeField] private AlertAction _alertEnum;
    [Space]
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _patrolPointsPrefab;
    [SerializeField] private Transform _explotionPrefab;
    [SerializeField] private Transform _playerTransform;

    private Enemy _enemy;
    private Transform[] _patrolPoints;
    private float _minDistanceDetect = 5f;

    private IIdleAction _idleAction;
    private IAlertAction _alertAction;

    private void Awake()
    {
        Transform patrolPointsParent = Instantiate(_patrolPointsPrefab, Vector3.zero, Quaternion.identity);
        _patrolPoints = patrolPointsParent.GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        _enemy = Instantiate(_enemyPrefab, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.identity);

        Idle();

        Alert();
    }

    private void Update()
    {
        if(_enemy == null) return;

        float distance = Vector3.Distance(_playerTransform.position, _enemy.transform.position);

        if (distance <= _minDistanceDetect)
        {
            _alertAction?.Action();
        }
        else
        {
            _idleAction?.Action();
        }
    }

    private void Idle()
    {
        switch (_idleEnum)
        {
            case IdleAction.PointsPatrol:
                _idleAction = new IdlePointsPatrol(_patrolPoints, _enemy.transform);
                break;

            case IdleAction.RandomPatrol:
                _idleAction = new IdleRandomPatrol(_enemy.transform);
                break;

            case IdleAction.Stand:
                _idleAction = new IdleStand();
                break;
        }
    }

    private void Alert()
    {
        switch (_alertEnum)
        {
            case AlertAction.RunToPlayer:
                _alertAction = new RunToPlayer(_enemy.transform, _playerTransform);
                break;

            case AlertAction.RunAwayFromPlayer:
                _alertAction = new RunAway(_enemy.transform, _playerTransform);
                break;

            case AlertAction.InstantDeath:
                _alertAction = new InstantDeath(_enemy, _explotionPrefab);
                break;
        }
    }
}
