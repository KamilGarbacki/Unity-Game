using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionControler : MonoBehaviour
{
    static bool[] tab = new bool[6];
    static int level = 1;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("NextLevel"))
        {
            SceneManager.LoadScene(LevelGenerator());
        }
        else if (collider.gameObject.CompareTag("Trophy"))
        {
            SceneManager.LoadScene(9);
        }
        else if(collider.gameObject.CompareTag("Enemy_Bullet"))
        {
            Player_HP.currentHp -= 1;
            gameOverScript.instance.GameOver();
        }
        else if (collider.gameObject.CompareTag("Medkit"))
        {
            Player_HP.currentHp += 3;
        }
        else if (collider.gameObject.CompareTag("Coin"))
        {
            Player_HP.money += 1;
            coinUi.instance.addCoin();
        }
        else if (collider.gameObject.CompareTag("Medkit_Shop"))
        {
            if(Player_HP.money >= 3)
            {
                Player_HP.currentHp += 3;
            }           
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            Player_HP.currentHp -= 1;
            gameOverScript.instance.GameOver();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Player_HP.currentHp -= 1;
            gameOverScript.instance.GameOver();
        }
    }

    int LevelGenerator()
    {
        int index = Random.Range(2, 7);
        
        if(level == 6)
        {
            return (7);
        }

        while (tab[index-1])
        {
            index = Random.Range(2, 7);
        }
        tab[index-1] = true;
        level++;
        return (index);
    }
}
