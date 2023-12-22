using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private float nextEnemySpawn = 0.0f;
    private float enemySpawnRate = 10.0f;
    private float speed = -2.0f;
    private const float DELTASPEED = 0.25f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if ( Time.time > nextEnemySpawn )
        {
            nextEnemySpawn = Time.time + enemySpawnRate;
            speed -= DELTASPEED;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0.0f, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bottom")
        {
            Destroy(this.gameObject);
        }

        else if (collision.tag == "Player")
        {
            Destroy(player);
        }

        else if (collision.tag == "Missile")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
