using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void playGame()
    {
        Player_HP.currentHp = Player_HP.maxHp;
        Player_HP.money = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void authors()
    {
        SceneManager.LoadScene("authors");
    }
}
