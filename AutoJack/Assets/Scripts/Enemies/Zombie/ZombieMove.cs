using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    public GameObject playerPos;
    public float zombieSpeed = 2f;
    private Rigidbody2D rb;
    Vector2 lookDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(playerPos);
        //rb.MovePosition(transform.position * zombieSpeed);
    }

    void FixedUpdate()
    {
        Vector2 playPos2D = new Vector2(playerPos.transform.position.x, playerPos.transform.position.y);
        lookDir = playPos2D - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        rb.MovePosition(rb.position + lookDir.normalized * zombieSpeed * Time.fixedDeltaTime);
    }


}
