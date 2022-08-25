using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DogMove : MonoBehaviour
{
    public float curDogSpeed = 2f;
    private Rigidbody2D rb;
    Vector2 lookDir;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        target = findClosestEnemy();
    }

    internal void setSpeed(int dogSpeed)
    {
        curDogSpeed = dogSpeed;
    }

    void FixedUpdate()
    {
        if(target!= null)
        {
            Vector2 targetPos2d = new Vector2(target.transform.position.x, target.transform.position.y);
            lookDir = targetPos2d - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

            rb.MovePosition(rb.position + lookDir * curDogSpeed * Time.fixedDeltaTime);
        }

    }
    private GameObject findClosestEnemy()
    {

        return GameObject.FindGameObjectsWithTag("Enemy").OrderBy(o => (o.transform.position - transform.position).sqrMagnitude)
        .FirstOrDefault();
        //GameObject closetEnemy = new GameObject();
        //var NearGameobjects = GameObject.FindGameObjectsWithTag("Enemy");
        //if (NearGameobjects.Length == 0)
        //{
        //    target = null;
        //    return null;
        //}
        //float closestDist = 999999;
        //for (int i = 0; i < NearGameobjects.Length; i++)
        //{
        //    float dist = Vector2.Distance(this.gameObject.transform.position, NearGameobjects[i].transform.position);
        //    if (dist < closestDist)
        //    {
        //        closetEnemy = NearGameobjects[i];
        //        closestDist = dist;
        //    }
        //}

    }
}
