using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>Spawnder</c> spawns enemies and background images
/// </summary>
public class Spawner : MonoBehaviour
{
    // prefabs to spawn
    public GameObject treeGroup;
    public GameObject bth;
    public GameObject bti;
    public GameObject btj;
    public GameObject moon;
    public GameObject enemy;
    public GameObject endScreen;
    public GameObject startScreen;
    public TextMeshProUGUI scoreText;
    private List<GameObject> bgs = new List<GameObject>();

    // enemy spawn boundaries
    private const float maxEnemyY = 3.5f;
    private const float minEnemyY = -4.5f;
    private const float spawnEnemyX = 15.0f;
    private float enemySpawnRate = 4.0f; // starts spawning at 4 seconds
    private float nextEnemySpawn = 0.0f;

    // background control
    private float tgSpawnRate = 15.0f;
    private float nextTgSpawn = 0.0f;
    private float moonSpawnRate = 25.0f;
    private float nextMoonSpawn = 25.0f;
    private float bgSpawnRate = 10.0f;
    private float nextBgSpawn = 10.0f;


    // enemy control vars
    private const float deltaSpeed = 0.25f;
    private const float ogSpeed = 4.0f;
    private const float updateSpawnRate = 15.0f;

    // score
    private float score = 0.0f;

    private void Start()
    {
        score = 0.0f;
        bgs.Add(bth);
        bgs.Add(bti);
        bgs.Add(btj);
        endScreen.SetActive(false);
    }

    /// <summary>
    /// Method <c>SpawnEnemy</c> spawns the enmey.
    /// Ranges are defined as x [-16, 15] and y [-5, 3]
    /// </summary>
    private void SpawnEnemy()
    {
        if (Time.time > nextEnemySpawn)
        {
            nextEnemySpawn = Time.time + enemySpawnRate;
            enemySpawnRate = Mathf.Max(deltaSpeed, ogSpeed - Mathf.Floor(Time.time / updateSpawnRate) * deltaSpeed);
            float yPos = Random.Range(minEnemyY, maxEnemyY);
            Instantiate(enemy, new Vector3(spawnEnemyX, yPos, 0), Quaternion.identity);
        }
    }

    /// <summary>
    /// Method <c>SpawnBackgroundObjects</c> spawns background objects
    /// </summary>
    private void SpawnBackgroundObjects()
    {
        if (Time.time > nextTgSpawn)
        {
            nextTgSpawn = Time.time + tgSpawnRate;
            tgSpawnRate = Random.Range(15.0f, 25.0f);
            Instantiate(treeGroup, new Vector3(10.0f, -0.5f, 0.0f), Quaternion.identity);
        }
        if (Time.time > nextMoonSpawn)
        {
            nextMoonSpawn = Time.time + moonSpawnRate;
            moonSpawnRate = Random.Range(20.0f, 40.0f);
            Instantiate(moon, new Vector3(10.0f, 3.0f, 0.0f), Quaternion.identity);
        }
        if (Time.time > nextBgSpawn)
        {
            nextBgSpawn = Time.time + bgSpawnRate;
            bgSpawnRate = Random.Range(10.0f, 15.0f);
            Instantiate(bgs[Random.Range(0, 3)], new Vector3(10.0f, 1.0f, 0.0f), Quaternion.identity);
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            SpawnEnemy();
            SpawnBackgroundObjects();
            score = 1000.0f * Time.deltaTime;
        }
        else if (startScreen.activeSelf)
        { }
        else
        {
            scoreText.text = "Score: " + ((int)score).ToString();
            endScreen.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            Application.Quit();
        }
    }
}
