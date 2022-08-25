using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrebuchetMove : MonoBehaviour
{
    private float turnSpeed = 3.5f;
    private Rigidbody2D rb;
    Vector2 lookDir;
    private GameObject target;
    private int TrebuchetLifetime =1;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyMyself());
    }
    private IEnumerator DestroyMyself()
    {
        yield return new WaitForSeconds(TrebuchetLifetime);
        player.GetComponent<PowerUpController>().removeFromTrebuchetList(transform.gameObject);
        Destroy(gameObject);

    }
    void Update()
    {
        target = findClosestEnemy();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 targetPos2d = new Vector2(target.transform.position.x, target.transform.position.y);
            lookDir = targetPos2d - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = Mathf.LerpAngle(rb.rotation, angle, Time.deltaTime * turnSpeed);

        }
    }

    internal void setTurnSpeed(float trebuchetTurnSpeed)
    {
        turnSpeed = trebuchetTurnSpeed;
    }
    public void setTrebuchetLifetime(int lifetime)
    {
        TrebuchetLifetime = lifetime;
    }


    private GameObject findClosestEnemy()
    {

        return GameObject.FindGameObjectsWithTag("Enemy").OrderBy(o => (o.transform.position - transform.position).sqrMagnitude)
        .FirstOrDefault();
    }

}
