using System;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    EnemyScript enemy;
    HealthController healthController;
    [Range(1, 15)]
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb;
    [SerializeField] private int _damage;
    [SerializeField] private int _price;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb.tag == ("Bullet") || rb.tag == ("RotatedBullet"))
        {
            rb.velocity = transform.right * speed;
        }
        else if (rb.tag == ("EnemyBullet"))
        {
            rb.velocity = Vector2.left * speed;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Kolider:" + collision);
        if (collision.tag == "Enemy" && rb.tag == "Bullet")
        {

            enemy = collision.GetComponent<EnemyScript>();
            Debug.Log("Uderzono przeciwnika" + enemy.name);
            enemy.minusHP(_damage);
            Debug.Log("Odjêto hp" +  _damage);
            Destroy(gameObject);
            Debug.Log("zniszczono obiekt");
        }
        if (collision.tag == "Player" && rb.tag == "EnemyBullet")
        {
            healthController = collision.GetComponent<HealthController>();
            healthController.minusHP(_damage);
            Destroy(gameObject);
        }
    }
    public int getDamage()
    {
        return _damage;
    }    
    public int getPrice()
    {
        return _price;
    }
}