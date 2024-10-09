using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private IdleAction _idleEnum;
    [SerializeField] private AlertAction _alertEnum;
    [Space]
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _patrolPointsPrefab;

    private Enemy _enemy;
    private Transform[] _patrolPoints;

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

        switch (_alertEnum)
        {
            case AlertAction.RunToPlayer:
                break;

            case AlertAction.RunAwayFromPlayer:
                break;

            case AlertAction.InstantDeath:
                break;
        }
    }

    private void Update()
    {
        if (_idleAction != null)
        {
            _idleAction.Action();
        }
        else
        {
            Debug.Log("idleAction = null");
        }
    }
}
