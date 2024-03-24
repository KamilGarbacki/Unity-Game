using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment : MonoBehaviour
{
    public float movmentSpeed = 6f; 
    public Rigidbody2D rb;
    Vector2 movment; 
    Vector2 mousePos; 
    public Camera cam;
    
    void Update() 
    {
        movment.x = Input.GetAxisRaw("Horizontal"); 
        movment.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); 
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movment * movmentSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position; 
        float angle; 
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
