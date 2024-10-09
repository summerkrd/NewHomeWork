using UnityEngine;

public class IdleRandomPatrol : IIdleAction
{
    private Transform _enemyTransform;
    private float _moveSpeed = 5f;
    private float _timer = 2f;

    public IdleRandomPatrol(Transform enemyTransform)
    {
        _enemyTransform = enemyTransform;
    }

    public void Action()
    {
        _timer -= Time.deltaTime;

        _enemyTransform.Translate(Vector3.forward * Time.deltaTime * _moveSpeed, Space.Self);

        if (_timer < 0)
        {
            NewRandomDirection();
        }
    }

    private void NewRandomDirection()
    {
        _timer = 3;

        int randomDirection = Random.Range(0,2) == 0 ? -90 : 90;

        Vector3 randomAngle = new Vector3(0, randomDirection, 0);
        
        _enemyTransform.Rotate(0, randomDirection, 0, Space.Self);
    }
}
