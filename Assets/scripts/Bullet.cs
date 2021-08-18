using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        Boss boss = collision.GetComponent<Boss>();

        if (collision.gameObject.tag == "Enemy")
        {
            print("Hello");
            enemy.TakeDamage(20);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            print("Hello");
            boss.TakeDamage(40);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Easy Enemy")
        {
            print("Hello");
            boss.TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
