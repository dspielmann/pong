using UnityEngine;

public class PaddleController1 : MonoBehaviour
{
    Rigidbody2D pad;
    Vector2 initial;
    public float displacement = 0.1f;

    private float initialHeight;

    void Start()
    {
        pad = GetComponent<Rigidbody2D>();
        initial = pad.transform.localPosition;
        initialHeight = transform.localScale.y;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && initial.y <= 4.50f)
            initial.y += displacement;
        else if (Input.GetKey(KeyCode.S) && initial.y >= -4.50f)
            initial.y -= displacement;

        pad.MovePosition(initial);
    }

    // Halve paddle size
    public void ShrinkHalf()
    {
        Vector3 scale = transform.localScale;
        scale.y = Mathf.Max(scale.y * 0.5f, 0.2f);
        transform.localScale = scale;
        Debug.Log("Left Paddle shrunk to " + scale.y);
    }

    // Reset to original size
    public void ResetSize()
    {
        Vector3 scale = transform.localScale;
        scale.y = initialHeight;
        transform.localScale = scale;
    }
}
