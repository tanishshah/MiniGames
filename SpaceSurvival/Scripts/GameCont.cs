using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameCont : MonoBehaviour
{
    // vars for scoring
    public TextMeshProUGUI scoreText;
    private const float DELAY = 1.0f;
    private float nextUpdate = 0.0f;
    private int score = 0;

    // vars for spawning enemies
    public GameObject enemy;
    private float nextEnemySpawn = 0.0f;
    private float enemySpawnRate = 4.0f;
    private const float DELTASPEED = 0.1f;
    private const float MAXSPAWNRATE = 0.3f;
    private const float UPDATESPAWNRATE = 10.0f;
    private const float MINENEMY_X= -13.5f;
    private const float MAXENEMY_X = 14.0f;
    private const float ENEMY_Y = 4.0f;

    void Update()
    {
        UpdateScore();
        SpawnEnemy();
        EndGame();
    }

    private void EndGame()
    {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            var missiles = GameObject.FindGameObjectsWithTag("Missile");

            foreach (var missile in missiles)
            {
                Destroy(missile);
            }
            foreach (var enemy in enemies)
            {
                Destroy(enemy);
            }
        }
        Application.Quit();
    }

    private void UpdateScore()
    {
        if (GameObject.FindGameObjectWithTag("Player") && Time.time > nextUpdate)
        {
            nextUpdate = Time.time + DELAY;
            score += 1;
            scoreText.text = "Score: " + score.ToString();
        }
    }

    private void SpawnEnemy()
    {
        if (Time.time > nextEnemySpawn)
        {
            nextEnemySpawn = Time.time + enemySpawnRate;
            enemySpawnRate = Mathf.Max(MAXSPAWNRATE, enemySpawnRate - Mathf.Floor(Time.time / UPDATESPAWNRATE) * DELTASPEED);
            float xPos = Random.Range(MINENEMY_X, MAXENEMY_X);
            Instantiate(enemy, new Vector3(xPos, ENEMY_Y, 0), Quaternion.identity);
        }
    }
}
