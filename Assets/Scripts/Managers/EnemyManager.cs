using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
public class EnemyManager : MonoBehaviour
{
    public Player player;
    public Enemy enemyPrefab;
    public List<Enemy> enemies;
    public Vector2 enemyCount;

    public void RestartEnemyManager()
    {
        DeleteEnemies();
        GenerateEnemies();
    }

    private void GenerateEnemies()
    {
        var randomEnemyCount = UnityEngine.Random.Range(enemyCount.x, enemyCount.y);
        for (int i = 0; i < randomEnemyCount; i++)
        {
            var enemyXPos  = UnityEngine.Random.Range(-15, 15);
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(enemyXPos, 0, 0+i*2);
            enemies.Add(newEnemy);
            newEnemy.StartEnemy(player);
        }
      
    }

    private void DeleteEnemies()
    {
        foreach (var e in enemies)
        {
            Destroy(e.gameObject);
        }
        enemies.Clear();
    }

    public void StopEnemies()
    {
        foreach (var e in enemies)
        {
            e.Stop();
        }
    }
}
