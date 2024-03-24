using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet2 : MonoBehaviour
{
    public GameObject hitEffect;
    public float animationDuration = 0.15f;
    float start;
   
    void Start()
    {
        start = Time.time;
    }
    
    void Update()
    {
        if (Time.time - start > 10)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, animationDuration);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Enemy") || collider.gameObject.CompareTag("Enemy_Bullet") || collider.gameObject.CompareTag("Bullet") || collider.gameObject.CompareTag("Laser"))
        {
            
        }
        else
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, animationDuration);
            Destroy(gameObject);
        }


    }
}
