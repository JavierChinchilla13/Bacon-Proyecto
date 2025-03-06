using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABoss : MonoBehaviour
{
    public Animator bossAnimator;
    public SpriteRenderer bossSpriteRenderer;
    public PolygonCollider2D bossCollider;
    public float movementSpeed = 1;
    private float bossWaitTime;
    public float initialWaitTime = 2;
    private int waypointIndex = 0;
    private Vector2 currentPosition;

    public Transform[] movementWaypoints;

    // Start is called before the first frame update
    void Start()
    {
        bossWaitTime = initialWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckBossMovement());
        CheckBossMovement();

        // Move the object from one point to another
        transform.position = Vector2.MoveTowards(transform.position, movementWaypoints[waypointIndex].transform.position, movementSpeed * Time.deltaTime);

        // Check if the object has reached the current waypoint
        if (Vector2.Distance(transform.position, movementWaypoints[waypointIndex].transform.position) < 0.1f)
        {
            // Check if the wait time is over
            if (bossWaitTime <= 0)
            {
                // Move to the next waypoint
                if (movementWaypoints[waypointIndex] != movementWaypoints[movementWaypoints.Length - 1])
                {
                    waypointIndex++;
                }
                else
                {
                    waypointIndex = 0;
                }
                bossWaitTime = initialWaitTime;
            }
            else
            {
                // Decrease the wait time
                bossWaitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckBossMovement()
    {
        currentPosition = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > currentPosition.x)
        {
            bossSpriteRenderer.flipX = false;
            bossCollider.transform.localScale = new Vector3(-1,1,1);  // Reset collider scale
            bossAnimator.SetBool("Idle", false);
        }
        else if (transform.position.x < currentPosition.x)
        {
            bossSpriteRenderer.flipX = true;
            bossCollider.transform.localScale = new Vector3(1,1,1);  // Flip collider in X axis
            bossAnimator.SetBool("Idle", false);
        }
        if (transform.position.x == currentPosition.x)
        {
            bossAnimator.SetBool("Idle", true);
        }
    }
}
