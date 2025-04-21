using UnityEngine;

public class KillingSquare : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" || collision.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
