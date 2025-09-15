using UnityEngine;
public class PaddleController : MonoBehaviour
{
Rigidbody2D pad;
Vector2 initial;
public float displacement;
// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{
pad = GetComponent<Rigidbody2D>();
initial = pad.transform.localPosition;
}
// Update is called once per frame
void Update()
{
if ((Input.GetKey(KeyCode.UpArrow))){
if (initial.y<=4.50)
initial.y=initial.y+displacement;
}
else if((Input.GetKey(KeyCode.DownArrow))){
if (initial.y>-4.50)
initial.y=initial.y-displacement;
}
pad.MovePosition(initial);
}
}