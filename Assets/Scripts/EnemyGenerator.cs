using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private IdleAction _idleActionEnum;
    [SerializeField] private ReactAction _reactActionEnum;

    private void Start()
    {
        Instantiate(_enemyPrefab, transform.position, Quaternion.identity);        
    }
}
