using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 1000;
    //public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();

        }

        if (health <= 300)
        {
            GetComponent<Animator>().SetBool("isEnrage", true);
        }

    }

    void Die()
    {
        Destroy(gameObject);

    }
}
