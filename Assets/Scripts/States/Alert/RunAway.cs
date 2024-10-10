using UnityEngine;

public class RunAway : IAlertAction
{
    private float _moveSpeed = 5f;
    private Transform _playerTransform;
    private Transform _enemyTransform;

    public RunAway(Transform enemyTransform, Transform playerTransform)
    {        
        _playerTransform = playerTransform;
        _enemyTransform = enemyTransform;
    }

    public void Action()
    {
        Vector3 moveDirection = _enemyTransform.position - _playerTransform.position;
        Vector3 normalizeMoveDirection = new Vector3(moveDirection.x, 0f, moveDirection.z).normalized;

        _enemyTransform.position += normalizeMoveDirection * Time.deltaTime * _moveSpeed;
    }
}
