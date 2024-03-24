using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject player;

    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1.8)
        {
            timer = 0;
            Vector3 direction = player.transform.position - transform.position;
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction);
            if(hitInfo.transform.name == "Player")
            {
                shoot();
            }
        }
    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
