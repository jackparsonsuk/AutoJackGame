using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMove : MonoBehaviour
{
    GameObject player;
    private Rect cameraRect;
    private Vector3 randomVector;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right*10;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //pos.x = Mathf.Clamp01(pos.x);
        //pos.y = Mathf.Clamp01(pos.y);
        if (pos.x < 0.0)
        {
            Debug.Log("I am left of the camera's view.");

            randomVector = Vector3.Reflect(randomVector, Vector3.right);
            transform.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.Reflect(transform.gameObject.GetComponent<Rigidbody2D>().velocity, Vector3.right);
        }

        if (1.0 < pos.x)
        {

            Debug.Log("I am right of the camera's view.");
            randomVector = Vector3.Reflect(randomVector, Vector3.left);
            transform.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.Reflect(transform.gameObject.GetComponent<Rigidbody2D>().velocity, Vector3.left);
        }

        if (pos.y < 0.0)
        {
            Debug.Log("I am below the camera's view.");
            randomVector = Vector3.Reflect(randomVector, Vector3.down);
            transform.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.Reflect(transform.gameObject.GetComponent<Rigidbody2D>().velocity, Vector3.down);
        }

        if (1.0 < pos.y)
        {
            Debug.Log("I am above the camera's view.");
            randomVector = Vector3.Reflect(randomVector, Vector3.up);
            transform.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.Reflect(transform.gameObject.GetComponent<Rigidbody2D>().velocity, Vector3.up);
        }
    }
}
