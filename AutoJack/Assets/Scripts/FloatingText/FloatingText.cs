using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float DestroyTime = 3f;
    public Vector3 RandomIntesity = new Vector3(0.5f,0,0);
    public Vector3 Offset = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

 
        transform.localPosition += Offset;
        transform.localPosition += new Vector3(Random.Range(-RandomIntesity.x, RandomIntesity.x),
            Random.Range(-RandomIntesity.y, RandomIntesity.y),
            Random.Range(-RandomIntesity.z, RandomIntesity.z));

        Destroy(gameObject, DestroyTime);
    }

}
