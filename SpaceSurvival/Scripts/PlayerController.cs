using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 inputDirection;
    private const float LEFTBOUND = -14.5f;
    private const float RIGHTBOUND = 14.5f;

    public GameObject missile;
    private const float COOLDOWN = 0.5f;
    private float nextFire = 0.0f;
    private Vector3 SHIFT = new Vector3(0.0f, 1.5f, 0.0f); 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        if (transform.position.x < LEFTBOUND)
        {
            transform.position = new Vector3(RIGHTBOUND, transform.position.y, 0);
        }
        else if (transform.position.x > RIGHTBOUND)
        {
            transform.position = new Vector3(LEFTBOUND, transform.position.y, 0);
        }
        FireMissile();
        CheckEnd();
    }

    void FixedUpdate()
    {
        rb.velocity = inputDirection * speed;
    }

    void FireMissile()
    {
        if (Input.GetKeyDown("space") && Time.time > nextFire)
        {
            nextFire = Time.time + COOLDOWN;
            GameObject fired = Instantiate(missile, transform.position + SHIFT, Quaternion.identity);
        }
    }

    void CheckEnd()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
