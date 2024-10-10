using UnityEngine;

public class InstantDeath : IAlertAction
{
    private Enemy _enemy;
    private Transform _explotionPrefab;

    public InstantDeath(Enemy enemy, Transform explotionPrefab)
    {
        _enemy = enemy;
        _explotionPrefab = explotionPrefab;
    }

    public void Action()
    {
        if (_enemy != null)
        {
            GameObject.Destroy(_enemy.gameObject);

            GameObject.Instantiate(_explotionPrefab, _enemy.transform.position, Quaternion.identity );
        }        
    }
}
