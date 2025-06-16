using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class GameDirector : MonoBehaviour
{
    public Player player;
    public EnemyManager enemyManager;
    public LevelManager levelManager;

    private void Start()
    {
        RestartLevel();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
    private void RestartLevel()
    {
        levelManager.RestartLevel();
        enemyManager.RestartEnemyManager();
        player.RestartPlayer();
    }

    public void levelCompleted()
    {
       enemyManager.StopEnemies();
    }
}
