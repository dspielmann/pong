using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public Vector2 direction;

    public scoreScript score; // reference to score manager

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(1, 1).normalized; // start diagonally
        rb.linearVelocity = direction * speed;

        // Find the ScoreManager
        score = GameObject.FindWithTag("logic").GetComponent<scoreScript>();
    }

    void Update()
    {
        rb.linearVelocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("paddle"))
        {
            // Bounce horizontally
            direction.x = -direction.x;
        }
        else if (collision.CompareTag("rightwall"))
        {
            // Left player scores
            if (score != null) score.AddPointLeft(1);
            ResetBall();
        }
        else if (collision.CompareTag("leftwall"))
        {
            // Right player scores
            if (score != null) score.AddPointRight(1);
            ResetBall();
        }
        else if (collision.CompareTag("topwall") || collision.CompareTag("bottomwall"))
        {
            // Bounce vertically
            direction.y = -direction.y;
        }
    }

    void ResetBall()
    {
        // Reset position
        rb.position = Vector2.zero;

        // Reset direction randomly so it doesn't always go the same way
        float dirX = Random.Range(0, 2) == 0 ? -1 : 1;
        float dirY = Random.Range(-1f, 1f);
        direction = new Vector2(dirX, dirY).normalized;

        rb.linearVelocity = direction * speed;
    }
}
