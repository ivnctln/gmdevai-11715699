using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int totalEnemies;
    private int enemiesLeft;
    private bool isPlayerAlive = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterEnemy(EnemyHP enemy)
    {
        totalEnemies++;
        enemiesLeft++;
    }

    public void EnemyDied(EnemyHP enemy)
    {
        enemiesLeft--;
        CheckForWin();
    }

    public void PlayerDied()
    {
        if (isPlayerAlive)
        {
            isPlayerAlive = false;
            Debug.Log("You Lost!");
        }
    }

    private void CheckForWin()
    {
        Debug.Log("Enemies Left: " + enemiesLeft);
        if (enemiesLeft <= 0 && isPlayerAlive)
        {
            Debug.Log("You Win!");

            PlayerControl playerControl = FindObjectOfType<PlayerControl>();
            if (playerControl != null)
            {
                playerControl.enabled = false;
            }
        }
    }
}
