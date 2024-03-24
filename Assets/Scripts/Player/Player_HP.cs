using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public static int maxHp = 10;
    public static int money = 0;
    public static int currentHp = 0;
    
    public healthBar healthBar;
    
    void Start()
    {
        healthBar.SetMaxHealth(maxHp);
        
    }
    
    void Update()
    {
        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        healthBar.SetHealth(currentHp);
    }
}
