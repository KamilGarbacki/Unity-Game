using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Behaviour : MonoBehaviour
{
    bool second_state;
    public GameObject Boss;
    public Transform bulletPos_L;
    public Transform bulletPos_SL;
    public Transform bulletPos_SR;
    public Transform bulletPos_R;

    public GameObject bulletPrefab_S;
    public GameObject bulletPrefab_N;

    public GameObject player;

    public float force;
    public float timer;

    public Boss_Death bossDeath;

    int Bullet_Counter = 0;
    int Bullet_Counter2 = 0;

    public Transform laserPosL;
    public Transform laserPosR;

    public LineRenderer lineRenderer1;
    public LineRenderer lineRenderer2;
    bool laserShoot;
    Rigidbody2D rb;


    void Start()
    {
        rb = Boss.GetComponent<Rigidbody2D>();
        lineRenderer1.enabled = false;
        lineRenderer2.enabled = false;
        second_state = false;
    }
    
    void Update()
    {
        if(bossDeath.bossHP <= (bossDeath.maxBossHP / 2))
        {
            second_state = true;
        }
        if(second_state == true)
        {
            SecondState();
        }
        else
        {
            FirstState();
        }
    }

    void FirstState()
    {
        timer += Time.deltaTime;
        if (timer > 1.3)
        {
            timer = 0;
            if(Bullet_Counter == 2)
            {
                StartCoroutine(Attack1_2());
                Bullet_Counter = 0;
            }
            else
            {
                StartCoroutine(Attack1_1());
                Bullet_Counter++;
            }
        }
    }



    void SecondState()
    {
        timer += Time.deltaTime;
        if (timer > 1.8)
        {
            timer = 0;
            if (Bullet_Counter2 == 3)
            {
                StartCoroutine(Attack2_1());
                Bullet_Counter2 = 0;
            }
            else if(Bullet_Counter2 == 2)
            {
                StartCoroutine(Attack1_2());
                Bullet_Counter2++;
            }
            else
            {
                StartCoroutine(Attack2_2());
                Bullet_Counter2++;
            }
        }
    }


    IEnumerator Attack1_1()
    {
        GameObject bullet4 = Instantiate(bulletPrefab_S, bulletPos_R.position, bulletPos_R.rotation);
        Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
        rb4.AddForce(bulletPos_R.up * force, ForceMode2D.Impulse);

        GameObject bullet1 = Instantiate(bulletPrefab_S, bulletPos_L.position, bulletPos_L.rotation);
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        rb1.AddForce(bulletPos_L.up * force, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.55f);

        GameObject bullet2 = Instantiate(bulletPrefab_S, bulletPos_SL.position, bulletPos_SL.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(bulletPos_SL.up * force, ForceMode2D.Impulse);

        GameObject bullet3 = Instantiate(bulletPrefab_S, bulletPos_SR.position, bulletPos_SR.rotation);
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce(bulletPos_SR.up * force, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1.8f);
    }

    IEnumerator Attack1_2()
    {
        Instantiate(bulletPrefab_N, bulletPos_L.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bulletPrefab_N, bulletPos_SL.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bulletPrefab_N, bulletPos_SR.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bulletPrefab_N, bulletPos_R.position, Quaternion.identity);
        yield return new WaitForSeconds(1.4f);
    }

    IEnumerator Attack2_1()
    {
        RaycastHit2D hitInfo1 = Physics2D.Raycast(laserPosL.position, laserPosL.up);
        RaycastHit2D hitInfo2 = Physics2D.Raycast(laserPosR.position, laserPosR.up);
        if (hitInfo1.transform.name == "Player" || hitInfo2.transform.name == "Player")
        {
            Player_HP.currentHp -= 1;
            gameOverScript.instance.GameOver();
        }
        lineRenderer1.SetPosition(0, laserPosL.position);
        lineRenderer1.SetPosition(1, hitInfo1.point);

        lineRenderer2.SetPosition(0, laserPosR.position);
        lineRenderer2.SetPosition(1, hitInfo2.point);

        rb.bodyType = RigidbodyType2D.Static;
        lineRenderer1.enabled = true;
        lineRenderer2.enabled = true;
        Instantiate(bulletPrefab_N, bulletPos_SL.position, Quaternion.identity);
        Instantiate(bulletPrefab_N, bulletPos_SR.position, Quaternion.identity);

        yield return new WaitForSeconds(0.4f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        lineRenderer1.enabled = false;
        lineRenderer2.enabled = false;
        yield return new WaitForSeconds(2f);
    }

    IEnumerator Attack2_2()
    {
        Instantiate(bulletPrefab_N, bulletPos_L.position, Quaternion.identity);

        GameObject bullet2 = Instantiate(bulletPrefab_S, bulletPos_SL.position, bulletPos_SL.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(bulletPos_SL.up * force, ForceMode2D.Impulse);

        GameObject bullet3 = Instantiate(bulletPrefab_S, bulletPos_SR.position, bulletPos_SR.rotation);
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce(bulletPos_SR.up * force, ForceMode2D.Impulse);

        Instantiate(bulletPrefab_N, bulletPos_R.position, Quaternion.identity);

        yield return new WaitForSeconds(1.5f);

        GameObject bullet4 = Instantiate(bulletPrefab_S, bulletPos_R.position, bulletPos_R.rotation);
        Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
        rb4.AddForce(bulletPos_R.up * force, ForceMode2D.Impulse);

        GameObject bullet1 = Instantiate(bulletPrefab_S, bulletPos_L.position, bulletPos_L.rotation);
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        rb1.AddForce(bulletPos_L.up * force, ForceMode2D.Impulse);

        Instantiate(bulletPrefab_N, bulletPos_L.position, Quaternion.identity);
        Instantiate(bulletPrefab_N, bulletPos_R.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
    }
}
