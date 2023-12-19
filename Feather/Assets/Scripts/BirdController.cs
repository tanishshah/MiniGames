using UnityEngine;

/// <summary>
/// Class <c>BirdController</c> Controlls the bird object
/// </summary>
public class BirdController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 inputDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        rb.velocity = inputDirection * speed;
    }

}
