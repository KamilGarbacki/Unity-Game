using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting2 : MonoBehaviour
{
    public Transform bulletPos1;
    public Transform bulletPos2;
    public Transform bulletPos3;

    public GameObject bulletPrefab;
    public GameObject player;
    private float timer;

    public float force;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2.3)
        {
            timer = 0;
            Vector3 direction = player.transform.position - transform.position;
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction);
            if (hitInfo.transform.name == "Player")
            {
                shoot();
            }

        }
    }
    void shoot()
    {
        GameObject bullet1 = Instantiate(bulletPrefab, bulletPos1.position, bulletPos1.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, bulletPos2.position, bulletPos2.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, bulletPos3.position, bulletPos3.rotation);

        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();

        rb1.AddForce(bulletPos1.up * force, ForceMode2D.Impulse);
        rb2.AddForce(bulletPos2.up * force, ForceMode2D.Impulse);
        rb3.AddForce(bulletPos3.up * force, ForceMode2D.Impulse);

    }

}
