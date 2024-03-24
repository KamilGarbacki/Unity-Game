using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Destroy : MonoBehaviour
{

    public int enemyHP;
    public GameObject CoinPrefab;
    public GameObject MedkitPrefab;
    Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D collision) //funkcja uaktywnia się przy kolizji
    {
        rb = GetComponent<Rigidbody2D>();

        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Laser"))
        {
            enemyHP --;
        }

        if (enemyHP <= 0)
        {
            Destroy(gameObject);
            int index = Random.Range(1, 11);
            if(index < 6)
            {
                Instantiate(CoinPrefab, rb.position, Quaternion.identity);
            }
            else if(index > 9)
            {
                Instantiate(MedkitPrefab, rb.position, Quaternion.identity);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        rb = GetComponent<Rigidbody2D>();

        if (collider.gameObject.CompareTag("Bullet") || collider.gameObject.CompareTag("Laser"))
        {
            enemyHP--;
        }

        if (enemyHP <= 0)
        {
            Destroy(gameObject);
            int index = Random.Range(1, 11);
            if (index < 6)
            {
                Instantiate(CoinPrefab, rb.position, Quaternion.identity);
            }
            else if (index > 9)
            {
                Instantiate(MedkitPrefab, rb.position, Quaternion.identity);
            }
        }
    }






}
