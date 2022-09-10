using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPDropScript : MonoBehaviour
{
    public float xpValue = 10;
    private float xpSizeScale = 0.02f;
    public void SetXPValue(float newXPValue)
    {
        xpValue = newXPValue;
        setXpSize();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<LevelUpController>().addXP(xpValue);
            Destroy(gameObject);
        }
    }
    void setXpSize()
    {
        this.transform.localScale = new Vector3(xpValue * xpSizeScale, xpValue * xpSizeScale, xpValue * xpSizeScale);
    }

}
 