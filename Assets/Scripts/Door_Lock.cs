using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Lock : MonoBehaviour
{
    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(enemy == null)
        {
            Destroy(gameObject);
        }
    }

}
