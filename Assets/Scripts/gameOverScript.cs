using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    public Transform Player;
    public Rigidbody2D rb;
    public static gameOverScript instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameObject.SetActive(false);
        rb = Player.GetComponent<Rigidbody2D>();
    }
    public void GameOver()
    {
        if (Player_HP.currentHp <= 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            gameObject.SetActive(true);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("menu");
    }
}

