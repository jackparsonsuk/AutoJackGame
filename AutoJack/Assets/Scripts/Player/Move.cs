using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float warpDistance = 1.5f;

    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 mousePos;

    Vector2 lookDir;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void IncreasePlayerSpeed(int increaseAmount)
    {
        moveSpeed += increaseAmount;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown("space"))
        {
            warp();
        }

    }


    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);



        lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        //GIZMOS
        Debug.DrawLine(transform.position, mousePos, Color.red);
        Debug.DrawLine(transform.position, rb.position + movement * moveSpeed * 50 * Time.fixedDeltaTime, Color.black);



    }


    private void warp()
    {

        //transform.position = new Vector3(transform.position.x +5, transform.position.y, transform.position.z);

        //transform.position = new Vector3(transform.position.x + (lookDir.x * 0.25f), transform.position.y + (lookDir.y * 0.25f), transform.position.z);
        transform.position = new Vector3(transform.position.x + movement.x * warpDistance, transform.position.y + movement.y * warpDistance, transform.position.z);

    }
}
