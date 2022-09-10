using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMove : MonoBehaviour
{
    public GameObject playerPos;
    public float zombieSpeed = 2f;
    public float JumpFreequency = 1f;
    private Rigidbody2D rb;
    Vector2 lookDir;
    private bool jumping;
    private float jumpModifer = 1f;

    // Start is called before the first frame update
    async void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player");
        //StartCoroutine(JumpCooldown());
    }

    void FixedUpdate()
    {
        Vector2 playPos2D = new Vector2(playerPos.transform.position.x, playerPos.transform.position.y);
        lookDir = playPos2D - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        rb.MovePosition(rb.position + lookDir.normalized * zombieSpeed * jumpModifer * Time.fixedDeltaTime);



    }

    //private IEnumerator JumpCooldown()
    //{
    //    jumping = false;
    //    float randomVariation = Random.Range(0, 3f);
    //    print("Jumping in " + (JumpFreequency + randomVariation) + " Seconds");
    //    jumpModifer = 1f;
    //    yield return new WaitForSeconds(JumpFreequency + randomVariation);
    //    //rb.velocity = Vector2.zero;
    //    //rb.AddForce(lookDir * 100f, ForceMode2D.Impulse);
    //    jumpModifer = 400f;
    //    print("Jumped");
    //    StartCoroutine(JumpCooldown());
    //}
}
