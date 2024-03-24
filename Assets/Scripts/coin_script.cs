using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_script : MonoBehaviour
{
    public float end;
    float start;

    void Start()
    {
        start = Time.time;
    }
    void Update()
    {
        if (Time.time - start > end)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
