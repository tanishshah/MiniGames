using UnityEngine;

public class MoveBG : MonoBehaviour
{
    private Rigidbody2D rb;
    private const float BGSPEED = -1.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(BGSPEED, 0.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LeftBounds")
        {
            Destroy(this.gameObject);
        }
    }
}
