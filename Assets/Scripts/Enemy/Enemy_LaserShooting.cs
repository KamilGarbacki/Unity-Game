using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LaserShooting : MonoBehaviour
{
    public Transform FirePoint;
    public Transform FirePoint1;
    public Transform FirePoint2;
    public Transform FirePoint3;
    int index;
    Rigidbody2D rb;

    public LineRenderer lineRenderer;
    
    float timer;
    public float Cooldown;
    bool Direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        index = Random.Range(0, 2);
        if(index == 0)
        {
            Direction = false;
        }
        else if(index == 1)
        {
            Direction = true;
        }
    }
    
    void Update()
    {
        if (index == 0)
        {
            Direction = false;
        }
        else if (index == 1)
        {
            Direction = true;
        }

        timer += Time.deltaTime;
        if (timer > Cooldown)
        {
            timer = 0;
            if(Direction == false)
            {
                StartCoroutine(ShootVertical());
                index = Random.Range(0, 2);
            }
            else if (Direction == true)
            {
                StartCoroutine(ShootHorizontal());
                index = Random.Range(0, 2);
            }
        }
    }

    IEnumerator ShootVertical()
    {
        rb.bodyType = RigidbodyType2D.Static;
        RaycastHit2D hitInfo1 = Physics2D.Raycast(FirePoint1.position, FirePoint1.up);
        RaycastHit2D hitInfo2 = Physics2D.Raycast(FirePoint2.position, FirePoint2.up);

        if (hitInfo1.transform.name == "Player" || hitInfo2.transform.name == "Player")
        {
            Player_HP.currentHp -= 1;
            gameOverScript.instance.GameOver();
        }

        lineRenderer.SetPosition(0, hitInfo2.point);
        lineRenderer.SetPosition(1, hitInfo1.point);

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.41f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        lineRenderer.enabled = false;
    }

    IEnumerator ShootHorizontal()
    {
        rb.bodyType = RigidbodyType2D.Static;
        RaycastHit2D hitInfo1 = Physics2D.Raycast(FirePoint.position, FirePoint.up);
        RaycastHit2D hitInfo2 = Physics2D.Raycast(FirePoint3.position, FirePoint3.up);

        if (hitInfo1.transform.name == "Player" || hitInfo2.transform.name == "Player")
        {
            Player_HP.currentHp -= 1;
            gameOverScript.instance.GameOver();
        }

        lineRenderer.SetPosition(0, hitInfo2.point);
        lineRenderer.SetPosition(1, hitInfo1.point);

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.41f);

        lineRenderer.enabled = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
