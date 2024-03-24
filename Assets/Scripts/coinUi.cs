using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coinUi : MonoBehaviour
{ 
    public static coinUi instance;
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        string coins = Player_HP.money.ToString();
        coinText.text = coins;
    }
    
    public void addCoin()
    {
        string coins = Player_HP.money.ToString();
        coinText.text = coins;
    }


}
