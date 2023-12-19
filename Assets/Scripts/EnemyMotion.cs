using UnityEngine;

/// <summary>
/// Class <c>BirdController</c> Class for handling the enemy motion
/// </summary>
public class EnemyMotion : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;

    private float enemySpeed = 0.5f;
    private float amplitude;
    private float freqMod;

    void Start()
    {
        amplitude = Random.Range(0.75f, 4.0f);
        freqMod = Random.Range(0.5f, 3.0f);
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        enemySpeed = Mathf.Max(0.5f, Time.time / 15);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(-1.0f*enemySpeed, amplitude*Mathf.Cos(freqMod*Time.time)*enemySpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LeftBounds")
        {
            Destroy(this.gameObject);
        }

        else if (collision.tag == "Player")
        {
            Destroy(player);
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            var bg = GameObject.FindGameObjectsWithTag("BG");

            foreach (var obj in bg)
            {
                Destroy(obj);
            }

            foreach (var enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }
}
