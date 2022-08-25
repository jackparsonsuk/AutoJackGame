using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMove : MonoBehaviour
{
    private GameObject player;
    public float speed = 10.0f;
    private Vector3 zAxis = new Vector3(0, 0, 0.1f);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(player.transform.position, zAxis, speed*Time.deltaTime);

    }
}
