using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPDropScript : MonoBehaviour
{
    public float xpValue = 10;
    public void SetXPValue(float newXPValue)
    {
        xpValue = newXPValue;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<LevelUpController>().addXP(xpValue);
            Destroy(gameObject);
        }
    }

}
