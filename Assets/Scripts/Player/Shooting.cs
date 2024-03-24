using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;



public class Shooting : MonoBehaviour
{
    EdgeCollider2D edgeCollider2D;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    public float cooldown;
    float lastShot;

    public static bool Laser_Weapon;
    public static bool Basic_Weapon;

    public LineRenderer lineRenderer;
    bool laserShoot;
    public RaycastHit2D hitInfo;

    public GameObject Collider;
    public BoxCollider2D col;
    public Rigidbody2D rb;

    void Start()
    {
        col = Collider.GetComponent<BoxCollider2D>();
        col.enabled = false;
    }

    void Update()
    {
        if (Laser_Weapon == true)
        {
            Basic_Weapon = false;
        }
        else
        {
            Basic_Weapon = true;
        }

        if (Input.GetButtonDown("Fire1")) 
        {
            if (Laser_Weapon == true)
            {
                StartCoroutine(ShootLaser());
            }
            if (Basic_Weapon == true)
            {
                Shoot();
            }

        }

        if(laserShoot == true)
        {
            hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
            SetCollider(firePoint.position, hitInfo.point);
        }
        
    }

    void Shoot()
    {
        if ((Time.time - lastShot) < cooldown)
        {
            return;
        }
        lastShot = Time.time;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //tworzy pocisk
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //dodajemy komponent Rigidbody2D do pocisku
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); //nadajemy pociskowi siłę
    }

    IEnumerator ShootLaser()
    {
        laserShoot = true;
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.2f);
        lineRenderer.enabled = false;
        laserShoot = false;
        col.enabled = false;
    }

    public void SetCollider(Vector3 startPos, Vector3 endPos)
    {
        rb = Collider.GetComponent<Rigidbody2D>();
        col.transform.parent = lineRenderer.transform;
        float lineLenght = Vector3.Distance(startPos, endPos);
        col.size = new Vector3(lineLenght, 0.1f, 1f);
        Vector3 midPoint = (startPos + endPos) / 2;
        col.transform.position = midPoint;
        
        float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
        if ((startPos.y < endPos.y) && (startPos.x > endPos.x) || (startPos.y > endPos.y) && (startPos.x < endPos.x))
        {
            angle *= -1;
        }
        angle = Mathf.Rad2Deg * Mathf.Atan(angle);

        rb.rotation = angle;
        col.enabled = true;
    }




}
