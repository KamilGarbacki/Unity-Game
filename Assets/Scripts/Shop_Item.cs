using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop_Item : MonoBehaviour
{
    public bool isLaser;
    public int price;
    public TextMeshProUGUI text;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if(Player_HP.money >= price)
            {
                if(isLaser)
                {
                    Shooting.Laser_Weapon = true;
                }
                Player_HP.money -= price;
                coinUi.instance.addCoin();
                Destroy(gameObject);
                Destroy(text);
            }
        }
    }
}
