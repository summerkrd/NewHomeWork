using UnityEngine;

public class RunToPlayer : IAlertAction
{
    private float _moveSpeed = 5f;
    private Transform _playerTransform;
    private Transform _enemyTransform;

    public RunToPlayer(Transform enemyTransform, Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _enemyTransform = enemyTransform;
    }

    public void Action()
    {
        Vector3 moveDirection = _playerTransform.position - _enemyTransform.position;
        Vector3 normalizeMoveDirection = new Vector3(moveDirection.x, 0f, moveDirection.z).normalized;

        _enemyTransform.position += normalizeMoveDirection * Time.deltaTime * _moveSpeed;
    }
}
