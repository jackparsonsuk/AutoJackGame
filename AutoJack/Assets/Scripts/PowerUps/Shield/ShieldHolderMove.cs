using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHolderMove : MonoBehaviour
{
    public float shieldSpeed = 10f;
 
    public void setShieldSpeed(float newSpeed)
    {
        shieldSpeed = newSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate((new Vector3(0, 0, 20) * Time.deltaTime * shieldSpeed));
    }
}
