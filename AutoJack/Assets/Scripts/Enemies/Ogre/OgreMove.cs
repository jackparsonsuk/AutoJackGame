using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreMove : MonoBehaviour
{
    public GameObject playerPos;
    public float ogreSpeed = 2f;
    private Rigidbody2D rb;
    Vector2 lookDir;

    public List<GameObject> movePoints = new List<GameObject>();
    private GameObject curMovePoint;
    private Vector2 playPos2D;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player");
        updateMovePoint();
    }
    void updateMovePoint()
    {
        int nextMoveIndex = Random.Range(0, movePoints.Count);
        if (movePoints[nextMoveIndex] == curMovePoint)
        {
            updateMovePoint();
        }
        curMovePoint = movePoints[nextMoveIndex];
    }
    void FixedUpdate()
    {
        playPos2D = new Vector2(playerPos.transform.position.x, playerPos.transform.position.y);
        Vector2 curMovePointPos = new Vector2(curMovePoint.transform.position.x, curMovePoint.transform.position.y);
        if (PlayerInRange())
        {
            lookDir = playPos2D - rb.position;
        }
        else
        {
            lookDir = curMovePointPos - rb.position;
            if (Vector2.Distance(transform.position, curMovePointPos) < 2f)
            {
                updateMovePoint();
            }
        }
        
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        rb.MovePosition(rb.position + lookDir.normalized * ogreSpeed * Time.fixedDeltaTime);

    }
    public bool PlayerInRange()
    {
        return Vector2.Distance(transform.position, playPos2D) < 50f;
    }

}
