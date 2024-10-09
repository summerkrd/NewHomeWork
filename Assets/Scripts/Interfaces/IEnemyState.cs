using UnityEngine;

public interface IEnemyState
{
    void Action(Enemy enemy, Player player);
}
