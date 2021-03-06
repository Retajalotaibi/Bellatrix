using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.Play("Shooting");
            shoot();

        }

        void shoot()
        {

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
