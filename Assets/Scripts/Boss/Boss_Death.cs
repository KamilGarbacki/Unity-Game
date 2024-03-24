using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Death : MonoBehaviour
{
    public int bossHP;
    public int maxBossHP;
    Rigidbody2D rb;
    public healthBar healthBar;
    public GameObject Trophy;

    void Start()
    {
        healthBar.SetMaxHealth(maxBossHP);
        bossHP = maxBossHP;
    }
    void Update()
    {
        healthBar.SetHealth(bossHP);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        rb = GetComponent<Rigidbody2D>();

        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Laser"))
        {
            bossHP--;
        }
        if (bossHP <= 0)
        {
            Destroy(healthBar.gameObject);
            Destroy(gameObject);
            Instantiate(Trophy, rb.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        rb = GetComponent<Rigidbody2D>();

        if (collider.gameObject.CompareTag("Bullet") || collider.gameObject.CompareTag("Laser"))
        {
            bossHP--;
        }
        if (bossHP <= 0)
        {           
            Destroy(healthBar.gameObject);
            Destroy(gameObject);
            Instantiate(Trophy, rb.position, Quaternion.identity);
        }
    }

}
