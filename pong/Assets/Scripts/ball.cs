using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public Vector2 direction;

    public scoreScript score;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.one.normalized;
        score = GameObject.FindGameObjectWithTag("logic").GetComponent<scoreScript>();
    }

    void Update()
    {
        rb.linearVelocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("paddle"))
        {
            direction.x = -direction.x;
        }
        else if (collision.CompareTag("rightwall"))
        {
            if (score != null) score.AddPointLeft(1);

            // Halve left paddle
            PaddleController1 leftPaddle = Object.FindFirstObjectByType<PaddleController1>();
            if (leftPaddle != null) leftPaddle.ShrinkHalf();

            ResetBall();
        }
        else if (collision.CompareTag("leftwall"))
        {
            if (score != null) score.AddPointRight(1);

            // Halve right paddle
            PaddleController rightPaddle = Object.FindFirstObjectByType<PaddleController>();
            if (rightPaddle != null) rightPaddle.ShrinkHalf();

            ResetBall();
        }
        else if (collision.CompareTag("topwall") || collision.CompareTag("bottomwall"))
        {
            direction.y = -direction.y;
        }
    }

    void ResetBall()
    {
        transform.position = Vector2.zero;
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f)).normalized;
    }
}
