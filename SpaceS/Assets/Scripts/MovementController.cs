using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody;
    float speed = 10;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GoUp();
        }
        if (Input.GetKey(KeyCode.A))
        {
            GoLeft();
        }
        if (Input.GetKey(KeyCode.S))
        {
            GoDown();
        }
        if (Input.GetKey(KeyCode.D))
        {
            GoLRight();
        }
    }
        void GoUp()
        {
            rigidbody.AddForce(Vector2.up*speed);
        }
    void GoLeft()
    {
        rigidbody.AddForce(Vector2.left * speed);
    }
    void GoLRight()
    {
        rigidbody.AddForce(Vector2.right * speed);
    }
    void GoDown()
    {
        rigidbody.AddForce(Vector2.down * speed);
    }
}
